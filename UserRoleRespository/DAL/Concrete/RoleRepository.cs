using Microsoft.EntityFrameworkCore;
using UserRoleModel.DAL;
using UserRoleModel.Entities;
using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.DAL.Concrete
{
    public class RoleRepository: IRoleRepository
    {
        private readonly MyContext _ctx;
        public RoleRepository(MyContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(Role role)
        {
            _ctx.Roles.Add(role);
            _ctx.SaveChanges();
        }

        public void Delete(Role role)
        {
            _ctx.Roles.Remove(role);
            _ctx.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return _ctx.Roles.Include(m => m.Permissions).ToList();
        }

        public Role GetById(int id)
        {
            return _ctx.Roles.Include(m => m.Permissions).Single(m => m.Id == id);
        }

        public void Update(Role role)
        {
            _ctx.Roles.Update(role);
            _ctx.SaveChanges();
        }
    }
}
