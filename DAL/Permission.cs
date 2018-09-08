using System.Collections.Generic;

namespace DAL
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
