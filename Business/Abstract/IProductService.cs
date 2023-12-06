using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{

    //IResult voidler icin IDataResult:Hem mesaji iceriyor hem de dondurecegi seyi(List<Product> gibi)iceren yapi

    //void olan IResult.Cunku onda data yok.Ama digerlerinin hepsi IDataResult.Cunku onlarda data var.
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>>GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        //Void olan yerde IResult donduruyoruz.
        IResult Add(Product product);
        IResult Update(Product product);

        IDataResult<Product> GetById(int productId);

      //  IDataResult<List<Product>> GetByCategoryId(int categoryId);

    }
}
