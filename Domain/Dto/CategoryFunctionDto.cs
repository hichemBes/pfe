using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
   public  class CategoryFunctionDto
    {
        public Guid CategoryFunctionID { get; set; }

        public Guid Fk_IdFunctionofUser { get; set; }
        public Guid CategoryId { get; set; }
        public Guid Fk_Function { get; set; }
   
        public string Categorytype { get; set; }
        public string FunctionName { get; set; }
        public string FunctionLabel { get; set; }
        public string Username { get; set; }
        public string Cin { get; set; }
        public string fillilaleName { get; set; }

    }
}
