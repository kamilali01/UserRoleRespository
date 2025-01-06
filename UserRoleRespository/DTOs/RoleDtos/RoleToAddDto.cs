using UserRoleModel.DTOs.PermissionDtos;

namespace UserRoleModel.DTOs.RoleDtos
{
    public record RoleToAddDto
    {
        public string Name { get; set; }
        public List<int> PermissionIds { get; set; }
    }
}
