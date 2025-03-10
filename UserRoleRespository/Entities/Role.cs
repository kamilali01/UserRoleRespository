﻿namespace UserRoleModel.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Permission> Permissions { get; set; }
        public bool IsDeleted { get; set; }
    }
}
