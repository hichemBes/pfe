using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public  class CategoryDto
    {

        public Guid CategoryId { get; set; }
        public string Categorytype { get; set; }
  
        public string NameCategorey { get; set; }
        public string Label { get; set; }
    }
}
