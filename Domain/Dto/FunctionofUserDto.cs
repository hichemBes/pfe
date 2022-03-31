using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public  class FunctionofUserDto
    {
        public Guid IdFunctionofUser { get; set; }
        public Guid Fk_User { get; set; }
        public Guid Fk_Function { get; set; }
        public string NameFunction { get; set; }
        public string LabelFunction { get; set; }
        public string cin { get; set; }
        public string username { get; set; }
        public string FillialeName { get; set; }
    }
}
