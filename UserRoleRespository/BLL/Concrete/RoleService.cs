using AutoMapper;
using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;
using UserRoleRespository.BLL.Abstract;
using UserRoleRespository.DAL.Abstract;

namespace UserRoleRespository.BLL.Concrete
{
    public class RoleService: IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repo;
        public RoleService(IMapper mapper, IRoleRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public void Add(RoleToAddDto role)
        {
            Role entity = _mapper.Map<Role>(role);
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            Role role = _repo.GetById(id);
            _repo.Delete(role);
        }

        public List<RoleToListDto> GetAll()
        {
            List<Role> entities = _repo.GetAll();
            return _mapper.Map<List<RoleToListDto>>(entities);
        }

        public RoleByIdDto GetById(int id)
        {
            Role role = _repo.GetById(id);
            return _mapper.Map<RoleByIdDto>(role);
        }

        public void Update(RoleToUpdateDto role)
        {
            Role entity = _mapper.Map<Role>(role);
            _repo.Update(entity);
        }
    }
}
