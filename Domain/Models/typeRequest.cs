using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
 public  class typeRequest
    {
        public Guid RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<typerequestCatg> typerequestCatgories { get; set; }
      
   
        
    }
}
