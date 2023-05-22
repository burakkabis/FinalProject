using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete

    //Businnes ayni zamanda dataaccess i kullaniyor.
    //*****Bir entity manageri kendisi haric baska dal i injekte edemez.Baska servisi injekte edebiliriz.*****
    //Businnesta inmemory entityframework asla yok.Businnes in bildigii IPorudctDal.Bu her sey olabilir.
{
    //Manager gorursek is katmaninin somut sinifidir.
    public class ProductManager : IProductService
    {
        //Soyut nesneyle baglanti kuruyruz.Ne Inmemory ismi ne de entity framework ismi gececek.
        IProductDal _productDal;
        ICategoryService _categoryService;

        //ProductManager new lendiginde bana bir IProductDal refereansi ver diyor.(InMemory EntityFramework..)
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = _categoryService;
        }


        //aTTRIBUTE:bIR METHODA ANLAM KATMAYA CALISTIGIMIZ YAPILARDIR.
        [SecuredOperation("product.add,admin")]

        [ValidationAspect(typeof(ProductValidator))] //Autofac devereye sokuyor.Attribute lara tipleri typeof ile atariz.
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)

        {
            //Aynı isimde ürün eklenemez
            //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez. ve 
            //result=kurala uymayan bir logic.
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName));
                //CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded()); //Baska bir kural geldiginde "," ile ekleyebiliriz buraya. 

            if (result != null) //Kurala uymayan bir logic olusmussa

            {

                return result;
            }
            //Is kodlarinadn geciyorsa veri erisimi cagirmamz lazim.(_productdal)

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);



        }
        [CacheAspect]//key,value
        public IDataResult<List<Product>> GetAll()
        {
            //is kodlarini geciyorsa veri erisimi cagiririz.
            // InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); EGER BOYLE YAZARSAK IS KODLARIMIZIN TAMAMI BELLEKLE CALISIR.
            //NOT:Bir is sinifi baska siniflari new lemez.Injeksion yapariz
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {

            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        [ValidationAspect(typeof(ProductValidator))] //Autofac devereye sokuyor.Attribute lara tipleri typeof ile atariz.
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);

            }
            return new SuccessResult();

        }


        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);

            }
            return new SuccessResult();

        }


        //private IResult CheckIfCategoryLimitExceded()
        //{

        //    var result = _categoryService.GetAll();
        //    if (result.Data.Count > 18)

        //    {
        //        return new ErrorResult(Messages.CategoryLimitExceded);


        //    }

        //    return new SuccessResult();


        //}


    }
}
