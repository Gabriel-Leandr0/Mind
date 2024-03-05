using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.ViewModels;

namespace Mind.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private static List<ReadUserViewModel> _users = new List<ReadUserViewModel>();


        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var newUser = new ReadUserViewModel
            {
                Id = _users.Count + 1, // Atribui um ID fictício
                UserName = createUserDto.UserName,
                RoleId = createUserDto.RoleId,
                Cpf = createUserDto.Cpf,
                // Outras propriedades do usuário
            };

            _users.Add(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
        
        
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
    }
}