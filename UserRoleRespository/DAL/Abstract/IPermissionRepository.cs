using UserRoleModel.Entities;

namespace UserRoleRespository.DAL.Abstract
{
    public interface IPermissionRepository
    {
        List<Permission> GetById(List<int> id);
        List<Permission> GetAll();
    }
}
