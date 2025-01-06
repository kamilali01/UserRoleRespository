using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserRoleModel.DAL;
using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.Entities;
using UserRoleModel.Mapper;

namespace UserRoleModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly MyContext _ctx;
        private readonly IMapper _mapper;

        public RoleController(MyContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Role> entities = _ctx.Roles.Include(r => r.Permissions).ToList();
            List<RoleToListDto> dto = _mapper.Map<List<RoleToListDto>>(entities);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            Role entity = _ctx.Roles.Include(r => r.Permissions).FirstOrDefault(r => r.Id == id); 
            RoleByIdDto dto = _mapper.Map<RoleByIdDto>(entity);
            return Ok(dto);

        }

        //bu metod hazir permissionlari yaratdigimiz role-a elave edir
        [HttpPost]
        public IActionResult Add([FromBody]RoleToAddDto dto)
        {

            Role entity = _mapper.Map<Role>(dto);
            List<Permission> permissions = _ctx.Permissions.Where(p => dto.PermissionIds.Contains(p.Id)).ToList();
            entity.Permissions = permissions;

            _ctx.Roles.Add(entity);
            _ctx.SaveChanges();

            return Ok();

        }

        //bu metod is role ile birlikde permission da yaradib elave edir
        [HttpPost("with-permission")]
        public IActionResult AddWithPermission([FromBody] RoleToAddWithPermissionDto dto)
        {

            Role entity = _mapper.Map<Role>(dto);

            _ctx.Roles.Add(entity);
            _ctx.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody] RoleToUpdateDto dto)
        {

            Role entity = _mapper.Map<Role>(dto);

            entity.Id = id;
            _ctx.Roles.Update(entity);
            _ctx.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            Role entity = _ctx.Roles.Find(id);
            entity.IsDeleted = true;
            _ctx.SaveChanges();

            return Ok(entity);

        }

    }
}
