using AutoMapper;
using BLL.DTO;
using BLL.Interface;
using DAL;
using DAL.Interface;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PermissionService : IPermissionService
    {
        private IRepository<Permission> _repo;
        private IMapper _mapper;

        public PermissionService(IRepository<Permission> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<PermissionDTO> GetPermissons()
        {
            IEnumerable<PermissionDTO> roles = _mapper.Map<IEnumerable<PermissionDTO>>(_repo.GetAll());
            return roles;
        }

        public void AddPermission(PermissionDTO permissionDTO)
        {
            if (permissionDTO != null)
            {
                Permission permission = _mapper.Map<Permission>(permissionDTO);
                _repo.Create(permission);
            }
        }

        public void EditPermission(PermissionDTO permissionDTO)
        {
            if (permissionDTO != null)
            {
                Permission permission = _mapper.Map<Permission>(permissionDTO);
                _repo.Update(permission);
            }
        }

        public void DeletePermission(int id)
        {
            if (id != 0)
            {
                _repo.Delete(id);
            }
        }
    }
}
