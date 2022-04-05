using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Foriegn_Dto
{
    public class UserDto: Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {
        public string filliale { get; set; }
        public Guid fk_filliale { get; set; }


    }
}
