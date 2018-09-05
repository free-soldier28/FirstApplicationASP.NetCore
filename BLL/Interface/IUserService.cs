using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        void AddUser(UserDTO user);
        void EditUser(UserDTO user);
        void DeleteUser(int id);
    }
}
