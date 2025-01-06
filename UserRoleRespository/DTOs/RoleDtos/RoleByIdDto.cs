using UserRoleModel.DTOs.PermissionDtos;

namespace UserRoleModel.DTOs.RoleDtos
{
    public record RoleByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PermissionByIdDto> Permissions { get; set; }
    }
}
