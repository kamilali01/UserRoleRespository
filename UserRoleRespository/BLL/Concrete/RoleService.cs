using AutoMapper;
using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;
using UserRoleRespository.BLL.Abstract;
using UserRoleRespository.DAL.Abstract;
using UserRoleRespository.DAL.UnitOfWork.Abstract;

namespace UserRoleRespository.BLL.Concrete
{
    public class RoleService: IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Add(RoleToAddDto role)
        {
            Role entity = _mapper.Map<Role>(role);
            List<Permission> permissions = _unitOfWork.PermissionRepository.GetById(role.PermissionIds);
            entity.Permissions = permissions;
            _unitOfWork.RoleRepository.Add(entity);
        }

        public void AddWithPermission(RoleToAddWithPermissionDto role)
        {
            Role entity = _mapper.Map<Role>(role);
            _unitOfWork.RoleRepository.Add(entity);
        }

        public void Delete(int id)
        {
            Role role = _unitOfWork.RoleRepository.GetById(id);
            _unitOfWork.RoleRepository.Delete(role);
        }

        public List<RoleToListDto> GetAll()
        {
            List<Role> entities = _unitOfWork.RoleRepository.GetAll();
            return _mapper.Map<List<RoleToListDto>>(entities);
        }

        public RoleByIdDto GetById(int id)
        {
            Role role = _unitOfWork.RoleRepository.GetById(id);
            return _mapper.Map<RoleByIdDto>(role);
        }

        public void Update(RoleToUpdateDto role)
        {
            Role entity = _mapper.Map<Role>(role);
            _unitOfWork.RoleRepository.Update(entity);
        }
    }
}
