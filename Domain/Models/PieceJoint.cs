using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PieceJoint
    {
        public Guid PieceId { get; set; }
        public string path { get; set; }
        public string Name { get; set; }
        public Guid fk_Request { get; set; }
        public Request Requests { get; set; }
    }
}
