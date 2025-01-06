namespace UserRoleModel.DTOs.UserDtos
{
    public record UserToAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
