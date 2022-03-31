using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public  class Organisme
    {
        public Guid OrganismeId { get; set; } 
            public string Name { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
