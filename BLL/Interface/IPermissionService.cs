using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IPermissionService
    {
        IEnumerable<PermissionDTO> GetPermissons();
        void AddPermission(PermissionDTO permission);
        void EditPermission(PermissionDTO user);
        void DeletePermission(int id);
    }
}
