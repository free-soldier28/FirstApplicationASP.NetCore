using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO : BaseDTO
    {
        public IEnumerable<RoleDTO> rolesDTO { get; set; }
    }
}
