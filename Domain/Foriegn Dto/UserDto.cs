using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Foriegn_Dto
{
    public class UserDto
    {
        public Guid userId { get; set; }
        public string name { get; set; }
        public string Cin { get; set; }
        public string Namefilliale { get; set; }
        public Guid fk_Filliale { get; set; }
        public string code { get; set; }
        
         
    }
}
