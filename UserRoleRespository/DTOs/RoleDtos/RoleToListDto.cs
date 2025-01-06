using UserRoleModel.DTOs.PermissionDtos;
using UserRoleModel.Entities;

namespace UserRoleModel.DTOs.RoleDtos
{
    public record RoleToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PermissionByIdDto> Permissions { get; set; }
    }
}
