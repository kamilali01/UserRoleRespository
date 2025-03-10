﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserRoleModel.DAL;
using UserRoleModel.DTOs.RoleDtos;
using UserRoleModel.DTOs.UserDtos;
using UserRoleModel.Entities;
using UserRoleRespository.BLL.Abstract;

namespace UserRoleModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dtos = _service.GetAll();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {

            var dto = _service.GetById(id);
            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Add([FromBody] RoleToAddDto dto)
        {
            _service.Add(dto);
            return Ok();
        }

        [HttpPost("WithPermission")]
        public IActionResult AddWithPermission([FromBody] RoleToAddWithPermissionDto dto)
        {
            _service.AddWithPermission(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] RoleToUpdateDto dto)
        {

            _service.Update(id, dto);

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            _service.Delete(id);

            return Ok();

        }

    }
}
