
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class FunctionofUser
    {

         public Guid IdFunctionofUser { get; set; }   
        public Guid Fk_User { get; set; }
      
        public Guid Fk_Function { get; set; }
        public Function Function { get; set; }
     
   




    }
}
