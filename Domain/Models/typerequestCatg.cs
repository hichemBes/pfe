using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class typerequestCatg
    {

       
        public Guid typerequestCatgID {get;set;}
        public typeRequest typeRequest { get; set; }
        public Category Category { get;set; }
        public Guid Fk_CategoryId { get; set; }
        public Guid FK_typeRequest { get;set;}

      

    }
}
