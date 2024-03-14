using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Domain.DTos;
using Mind.Domain.Models;
using Mind.Domain.ViewModels;
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
    public IActionResult CreateUser([FromBody] CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { Id = user.Id }, user);
    }



    [HttpGet]
    public IEnumerable<ReadUserDto> GetUsersList()
    {

        var userList = _mapper.Map<List<ReadUserDto>>(_context.Users.ToList());
        return userList;

    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Retorna 404 se o usuário não for encontrado
        }

        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto); // Retorna 200 e o usuário se encontrado
    }

}