using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cinema.Dal.Dbo;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Dal.Dbo
{
    public class RoleDbo : IdentityRole<Guid>
    {
        [Required]
        public string Title { get; set; }

        public List<UsersRoleDbo> UsersRoles { get; set; }
    }
}
