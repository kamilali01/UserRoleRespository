namespace UserRoleModel.DTOs.PermissionDtos
{
    public record PermissionToAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
