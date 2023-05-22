using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Product ile ilgili veri tabaninda yapacagim operasyonlari iceren interface(Add, Delete ,Update...)
    //veri erisim islerini yapiyor
    //Her entitty diger katmanlarda kodluyoruz.Product Category...
    public interface IProductDal:IEntityRepository<Product>
    {

        List<ProductDetailDto> GetProductDetails();


    }
}
