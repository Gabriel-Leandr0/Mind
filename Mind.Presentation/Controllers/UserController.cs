using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mind.Application.Interfaces;
using Mind.Domain.DTos;
using Mind.Domain.DTos.User;
using Mind.Domain.Models;
using Mind.Infrastructure.Data;
using Mind.Read.Interface;

namespace Mind.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IUserQuery _userQuery;

    public UserController(IMapper mapper, IUserService userService, IUserQuery userQuery)
    {
        _mapper = mapper;
        _userService = userService;
        _userQuery = userQuery;
    }

    [HttpPost("api/users/create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResponseGeneric>> CreateUser(CreateUserDto createUserDto)
    {
        return await _userService.CreateUser(createUserDto);
    }

    [HttpPut("api/users/update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ResponseGeneric>> UpdateUser(UpdateUserDto updateUserDto)
    {
        return await _userService.UpdateUser(updateUserDto);
    }

    [HttpGet("api/users/find")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> FindUser(string email)
    {
        var user = await _userQuery.GetUserByEmail(email);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
}