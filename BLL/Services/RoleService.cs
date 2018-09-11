using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL;
using Repository.Interface;
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

        public RoleDTO GetRole(int id)
        {
            RoleDTO roleDTO = null;

            if (id != 0)
            {
                roleDTO = _mapper.Map<RoleDTO>(_repo.GetById(id));
            }
            return roleDTO;
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
