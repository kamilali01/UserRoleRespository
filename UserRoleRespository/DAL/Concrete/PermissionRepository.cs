using UserRoleModel.DAL;
using UserRoleModel.Entities;
using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.DAL.Concrete
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly MyContext _ctx;
        public PermissionRepository(MyContext ctx)
        {
            _ctx = ctx;
        }
        public List<Permission> GetAll()
        {
            return _ctx.Permissions.ToList();
        }

        public List<Permission> GetById(List<int> id)
        {
            //return _ctx.Permissions.Find(p => p.Id == id);

            return _ctx.Permissions
               .Where(p => id.Contains(p.Id))
               .ToList();
        }
    }
    
}
