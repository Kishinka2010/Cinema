using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Dal.Dbo
{
    public class UsersDbo: IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<UsersRoleDbo> UsersRoles { get; set; }


    }
}
