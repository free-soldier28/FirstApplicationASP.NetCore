using AutoMapper;
using BLL.DTO;
using WebApp.Model;

namespace WebApp
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<RoleDTO, RoleViewModel>().ReverseMap();
            CreateMap<PermissionDTO, PermissionViewModel>().ReverseMap();
        }
    }
}
