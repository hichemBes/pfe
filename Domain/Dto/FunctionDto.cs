using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
public class FunctionDto
    {
        public Guid IdFunction { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public Guid IdFunctionofUser { get; set; }
      
    }
}
