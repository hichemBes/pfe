using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Function
    {
        public Guid IdFunction { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public ICollection<FunctionofUser> FunctionofUsers { get; set; }
        public ICollection<CategoryFunction> CategoryFunction {get; set; }

    }
}
