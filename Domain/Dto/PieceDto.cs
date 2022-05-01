using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class PieceDto
    {
        public Guid PieceId { get; set; }
        public string path { get; set; }
        public string Name { get; set; }
        public Guid fk_Request { get; set; }
        public Guid  fk_user { get; set; }
    }
}
