using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    //IDataResult da islem sonucu ve msaji iceriyor.Bunlar IResult da var.O yuzde IResult dan implementasyon yapiyor.Ek olarak T turunde Data olacak.
    //T:Urun ,urun listesi,categoir,categori listesi,dto...
    public interface IDataResult<T>:IResult
    {
        T Data { get; }

    }
}
