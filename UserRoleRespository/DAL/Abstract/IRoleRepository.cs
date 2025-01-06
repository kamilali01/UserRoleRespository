using UserRoleModel.Entities;

namespace UserRoleRespository.DAL.Abstract
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
