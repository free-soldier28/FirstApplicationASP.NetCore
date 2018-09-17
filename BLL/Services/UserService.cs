using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL;
using Repository.Interface;
using EntityFrameworkPaginate;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private AppDBContext _db;
        private IRepository<User> _repo;
        private IMapper _mapper;

        public UserService(IRepository<User> repo, IMapper mapper, AppDBContext db)
        {
            _repo = repo;
            _mapper = mapper;
            _db = db;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_db.Users.Select(p => new UserDTO
            {
                Id = p.Id,
                Name = p.Name,
                rolesDTO = _mapper.Map<List<RoleDTO>>(p.UserRoles.Select(x => x.Role))
            }));
            //return _mapper.Map<IEnumerable<UserDTO>>(_repo.GetAll());
        }

        public IEnumerable<UserDTO> GetUsersRolesPagination(int pageNumber, int pageSize)
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_db.Users);
        }

        //public async Task<IEnumerable<UserDTO>> GetUsersRolesPaginationAsync(int numberPage, int itemsPerPage)
        //{
        //    int startIndex = itemsPerPage * (numberPage - 1);
        //    IQueryable<User> source = _db.Users;
        //    var count = await source.CountAsync();
        //}

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
