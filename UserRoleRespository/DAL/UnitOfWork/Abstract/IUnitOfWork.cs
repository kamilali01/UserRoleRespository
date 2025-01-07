using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        void Commit();
    }
}
