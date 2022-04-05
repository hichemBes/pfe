using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class RequestDto
    {

        public Guid RequestId { get; set; }
        public string status { get; set; }
        public DateTime CreationDate { get; set; }
        public string RequestDescription { get; set; }
        public string  Filliale { get; set; }
        public Guid fk_RequestType { get; set; }
        public string username { get; set; }
       
        public Guid fk_Organisme { get; set; }
        public string requesttype { get; set; }
        public string Organisme { get; set; }

    }
}
