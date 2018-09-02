using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public User User { get; set; }
    }
}
