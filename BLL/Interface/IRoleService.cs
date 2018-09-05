using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetRoles();
        void AddRole(RoleDTO role);
        void EditRole(RoleDTO role);
        void DeleteRole(int id);
    }
}
