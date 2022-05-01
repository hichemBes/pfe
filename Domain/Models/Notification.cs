using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public  class Notification
    {
        public Guid  Id { get; set; }
        public string Message  { get; set; }
        public Guid RequestId { get; set; }
        public Guid userId { get; set; }

    }
}
