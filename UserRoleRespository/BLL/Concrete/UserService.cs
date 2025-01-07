using AutoMapper;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;
using UserRoleRespository.BLL.Abstract;
using UserRoleRespository.DAL.Abstract;
using UserRoleRespository.DAL.UnitOfWork.Abstract;

namespace UserRoleRespository.BLL.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Add(UserToAddDto user)
        {
            User entity = _mapper.Map<User>(user);
            _unitOfWork.UserRepository.Add(entity);
        }

        public void Delete(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            _unitOfWork.UserRepository.Delete(user);
        }

        public List<UserToListDto> GetAll()
        {
            List<User> entities = _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<List<UserToListDto>>(entities);
        }

        public UserByIdDto GetById(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map<UserByIdDto>(user);
        }

        public void Update(int id, UserToUpdateDto user)
        {
            User entity = _mapper.Map<User>(user);
            entity.Id = id;
            _unitOfWork.UserRepository.Update(entity);
        }
    }
}
