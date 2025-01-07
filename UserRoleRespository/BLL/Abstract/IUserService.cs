using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;

namespace UserRoleRespository.BLL.Abstract
{
    public interface IUserService
    {
        List<UserToListDto> GetAll();
        UserByIdDto GetById(int id);
        void Add(UserToAddDto user);
        void Update(int id,UserToUpdateDto user);
        void Delete(int id);
    }
}
