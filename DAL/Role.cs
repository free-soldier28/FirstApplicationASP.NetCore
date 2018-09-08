using System.Collections.Generic;

namespace DAL
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
