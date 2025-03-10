﻿using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.DTOs.UserDtos;

namespace UserRoleRespository.BLL.Abstract
{
    public interface IRoleService
    {
        List<RoleToListDto> GetAll();
        RoleByIdDto GetById(int id);
        void Add(RoleToAddDto role);
        void AddWithPermission(RoleToAddWithPermissionDto role);
        void Update(int id, RoleToUpdateDto role);
        void Delete(int id);
    }
}
