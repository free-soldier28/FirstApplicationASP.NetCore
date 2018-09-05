using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL;
using DAL.Interface;
using System.Collections.Generic;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private IRepository<Role> _repo;
        private IMapper _mapper;

        public RoleService(IRepository<Role> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
           IEnumerable<RoleDTO> roles = _mapper.Map<IEnumerable<RoleDTO>>(_repo.GetAll());
           return roles;
        }

        public void AddRole(RoleDTO roleDTO)
        {
            if (roleDTO != null)
            {
                Role role = _mapper.Map<Role>(roleDTO);
                _repo.Create(role);
            }
        }

        public void EditRole(RoleDTO roleDTO)
        {
            if (roleDTO != null)
            {
                Role role = _mapper.Map<Role>(roleDTO);
                _repo.Update(role);
            }
        }

        public void DeleteRole(int id)
        {
            if (id != 0)
            {
                _repo.Delete(id);
            }
        }
    }
}
