using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL;
using Repository.Interface;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repo;
        private IMapper _mapper;

        public UserService(IRepository<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_repo.GetAll());
        }

        public UserDTO GetUser(int id)
        {
            UserDTO userDTO = null;

            if(id != 0)
            {
                userDTO = _mapper.Map<UserDTO>(_repo.GetById(id));
            }
            return userDTO;
        }

        public void AddUser(UserDTO userDTO)
        {
            if (userDTO != null)
            {
                User user= _mapper.Map<User>(userDTO);
                _repo.Create(user);
            }
        }

        public void EditUser(UserDTO userDTO)
        {
            if (userDTO != null)
            {
                User user = _mapper.Map<User>(userDTO);
                _repo.Update(user);
            }
        }

        public void DeleteUser(int id)
        {
            if (id != 0)
            {
                _repo.Delete(id);
            }
        }
    }
}
