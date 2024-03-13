using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.Models;
using Mind.Infrastructure.Data;

namespace Mind.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly MindDbContext _context;
        private readonly IMapper _mapper;

        public RoleController(MindDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult CreateRole([FromBody] CreateRoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            _context.Roles.Add(role);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRoleById), new { Id = role.Id }, role);
        }

        [HttpGet]
        public IEnumerable<ReadRoleDto> GetRolesList()
        {

            var rolesList = _mapper.Map<List<ReadRoleDto>>(_context.Roles.ToList());
            return rolesList;

        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound(); // Retorna 404 se o usuário não for encontrado
            }

            var roleDto = _mapper.Map<ReadRoleDto>(role);
            return Ok(roleDto); // Retorna 200 e o usuário se encontrado
        }

    }
}