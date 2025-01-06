using UserRoleModel.DAL;
using UserRoleModel.Entities;
using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.DAL.Concrete
{
    public class UserRepisotory : IUserRepository
    {
        private readonly MyContext _ctx;
        public UserRepisotory(MyContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void Delete(User user)
        {
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public User GetById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public void Update(User user)
        {
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }
    }
}
