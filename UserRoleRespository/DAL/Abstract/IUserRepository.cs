using UserRoleModel.Entities;

namespace UserRoleRespository.DAL.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
