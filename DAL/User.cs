using System.Collections.Generic;

namespace DAL
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
