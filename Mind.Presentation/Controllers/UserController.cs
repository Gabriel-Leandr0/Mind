using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.Models;
using Mind.Infrastructure.Data;

namespace Mind.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly MindDbContext _context;
    private readonly IMapper _mapper;

    public UserController(MindDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }



    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IEnumerable<ReadUserDto> GetAllUsers()
    {

        var userList = _mapper.Map<List<ReadUserDto>>(_context.Users.ToList());
        return userList;

    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto);
    }

}