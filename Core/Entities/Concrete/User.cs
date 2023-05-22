//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.Entities.Concrete
//{

//    //Butun projelerde yetkilendirme oldugu icin(yani bu nesneler oldugu icin 
//    //core olmayan entitites yerine core daki entitiese yazdik.
//    public class User:IEntity
//    {

//        public int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public byte[] PasswordSalt { get; set; }
//        public byte[] PasswordHash { get; set; }
//        public bool Status { get; set; }
//    }
//}


using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

    }
}