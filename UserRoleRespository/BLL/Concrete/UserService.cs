using AutoMapper;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;
using UserRoleRespository.BLL.Abstract;
using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        public UserService(IMapper mapper, IUserRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public void Add(UserToAddDto user)
        {
            User entity = _mapper.Map<User>(user);
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            User user = _repo.GetById(id);
            _repo.Delete(user);
        }

        public List<UserToListDto> GetAll()
        {
            List<User> entities = _repo.GetAll();
            return _mapper.Map<List<UserToListDto>>(entities);
        }

        public UserByIdDto GetById(int id)
        {
            User user = _repo.GetById(id);
            return _mapper.Map<UserByIdDto>(user);
        }

        public void Update(UserToUpdateDto user)
        {
            User entity = _mapper.Map<User>(user);
            _repo.Update(entity);
        }
    }
}
