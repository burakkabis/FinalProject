using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{

    //Category ile ilgili dis dunyaya neyi servis etmek istiyorsak onu yaziyrouz.
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
       IDataResult< Category> GetById(int categoryId);
    }
}
