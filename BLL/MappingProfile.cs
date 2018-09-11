using AutoMapper;
using BLL.DTO;
using DAL;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<PermissionDTO, Permission>().ReverseMap();
        }
    }
}
