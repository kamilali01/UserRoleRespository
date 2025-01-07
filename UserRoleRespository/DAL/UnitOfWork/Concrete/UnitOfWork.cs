using UserRoleModel.DAL;
using UserRoleRespository.DAL.Abstract;
using UserRoleRespository.DAL.UnitOfWork.Abstract;

namespace UserRoleRespository.DAL.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IRoleRepository RoleRepository { get; }
        public IPermissionRepository PermissionRepository { get; }

        private readonly MyContext _ctx;
        public UnitOfWork(MyContext ctx, IUserRepository userRepository, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _ctx = ctx;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            PermissionRepository = permissionRepository;
        }

        public void Commit()
        {
           _ctx.SaveChanges();
        }
    }
}
