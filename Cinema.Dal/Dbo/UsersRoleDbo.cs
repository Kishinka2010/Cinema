using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Dal.Dbo
{
    [Table("AspNetUserRoles")]
    public class UsersRoleDbo : IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; }

        public override Guid RoleId { get; set; }

        public RoleDbo Role { get; set; }

        public UsersDbo Users { get; set; }
    }
}
