using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class Category
    {

        public Guid CategoryId { get; set; }
        public string Categorytype { get; set; }
     
        public ICollection<CategoryFunction> CategoryFunction { get; set; }
        public ICollection<typerequestCatg> typerequestCatgories { get; set; }
    }
}
