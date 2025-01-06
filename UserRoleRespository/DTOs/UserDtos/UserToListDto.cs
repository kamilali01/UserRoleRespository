using UserRoleModel.DTOs.RoleDtos;

namespace UserRoleModel.DTOs.UserDtos
{
    public record UserToListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleByIdDto Role { get; set; }
    }
}
