using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class Request
    {
        public Guid RequestId { get; set; }
      
        public Status state { get; set; }

        public enum Status
        {
            NotDone,
            InProgress,
            Done

        }
        public DateTime CreationDate { get; set; }
        public string RequestDescription { get; set; }
        public Guid fk_Filliale { get; set; }
        public Guid Fk_User { get; set; }

        public Guid fk_RequestType { get; set; }
        public typeRequest RequestType { get; set; }
        public ICollection<PieceJoint> Pieces { get; set; }
        public Organisme Organisme { get; set; }
        public Guid fk_Organisme { get; set; }

    }
}
