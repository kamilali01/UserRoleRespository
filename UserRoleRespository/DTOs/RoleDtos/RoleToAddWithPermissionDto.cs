using UserRoleModel.DTOs.PermissionDtos;

namespace UserRoleModel.DTOs.RoleDtos
{
    public record RoleToAddWithPermissionDto
    {
        public string Name { get; set; }
        public List<PermissionToAddDto> Permissions { get; set; }
    }
}
