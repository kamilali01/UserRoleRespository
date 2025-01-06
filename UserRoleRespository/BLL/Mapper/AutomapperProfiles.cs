using AutoMapper;
using UserRoleModel.DTOs.PermissionDtos;
using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;

namespace UserRoleRespository.BLL.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Role, RoleToListDto>();
            CreateMap<Role, RoleByIdDto>();
            CreateMap<RoleToAddDto, Role>();
            CreateMap<RoleToAddWithPermissionDto, Role>();
            CreateMap<RoleToUpdateDto, Role>();

            CreateMap<User, UserToListDto>();
            CreateMap<User, UserByIdDto>();
            CreateMap<UserToAddDto, User>();
            CreateMap<UserToUpdateDto, User>();

            //CreateMap<Permission, PermissionToListDto>();
            CreateMap<Permission, PermissionByIdDto>();
            CreateMap<PermissionToAddDto, Permission>();
            //CreateMap<PermissionToUpdateDto, Permission>();
        }
    }
}
