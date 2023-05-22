using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //Static:Surekli newlemememizi sagliyor.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazka 10 urun olabilir";
        public static string ProductNameAlreadyExist="Bu isimde zaten bir isim var.";
        public static string CategoryLimitExceded ="Kategori limiti asildigi icin yeni urun eklenemiyor.";
        public static string  AuthorizationDenied="Yetkiniz yok.";
    }
}
