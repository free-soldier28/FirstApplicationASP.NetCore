using System.Collections.Generic;

namespace DAL
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
