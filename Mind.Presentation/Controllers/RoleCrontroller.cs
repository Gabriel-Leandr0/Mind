using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;

namespace Mind.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            return Ok(createRoleDto);
        }
        
    }
}