using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult: Result       //Inheritance

    {

        public SuccessResult(string message) : base(true, message)
        { 
        
        
        }

        //Mesaj vermedim.Base e true yolluyoruz.
        public SuccessResult() : base(true)
        { 
        
        }



    }
}
