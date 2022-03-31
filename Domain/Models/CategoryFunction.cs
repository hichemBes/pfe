using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class CategoryFunction
    {
        public Guid CategoryFunctionid{ get; set; }

        public Guid Fk_IdFunction{ get; set; }
        public Function Function { get; set; }  
        public Category Category { get; set; }
        public Guid Fk_CategoryId { get; set; }
    }
}
