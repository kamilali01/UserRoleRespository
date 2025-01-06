namespace UserRoleModel.DTOs.PermissionDtos
{
    public record PermissionByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
