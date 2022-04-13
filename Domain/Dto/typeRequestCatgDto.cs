using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class typeRequestCatgDto
    {
        public Guid typerequestCatgID { get; set; }
        public Guid Fk_CategoryId { get; set; }
        public string RequestTypeName { get; set; }
      

        public string  Categorietype {get;set;}
    

    }
}
