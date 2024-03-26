using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Mind.Application.Interfaces;
using Mind.Domain.DTos;
using Mind.Domain.DTos.User;
using Mind.Domain.ViewModels;
using Mind.Infrastructure.Data;
using Mind.Infrastructure.Encryption;
using Mind.Infrastructure.Token;
using Mind.Infrastructure.Utils;
using Mind.Read.Interface;

namespace Mind.Application.Services;

public class UserService : IUserService
{
    private readonly IUserQuery _userQuery;
    private readonly IEncryptionService _encryptionService;
    private readonly ITokenService<UserViewModel> _tokenService;
    private readonly MindDbContext _context;
    private readonly IWebHostEnvironment _env;

    public UserService(IUserQuery userQuery, IEncryptionService encryptionService, ITokenService<UserViewModel> tokenService, MindDbContext context, IWebHostEnvironment env)
    {
        _userQuery = userQuery;
        _encryptionService = encryptionService;
        _tokenService = tokenService;
        _context = context;
        _env = env;
    }

    public async Task<ResponseGeneric> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var user = await _userQuery.GetUserByEmail(createUserDto.Email);

            if (user != null)
                return (new ResponseGeneric()
                {
                    response = new ResponseViewModel(StatusCodes.Status400BadRequest, "Usuario já Cadastrado!"),
                    data = null
                });

            if (!ConverterUtils.IsPasswordValid(createUserDto.Password))
                return (new ResponseGeneric()
                {
                    response = new ResponseViewModel(StatusCodes.Status400BadRequest, "Informe uma senha com:\n- mínimo de 6 caracteres e máximo de 30 caracteres\n- ao menos 1 letra maiúscula\n- ao menos 1 caractere especial\n- ao menos 1 número"),
                    data = null
                });

            _context.Users.Add(new Domain.Models.User()
            {
                Fullname = createUserDto.Fullname,
                Email = createUserDto.Email,
                Nickname = createUserDto.Nickname,
                Password = _encryptionService.GenerateHashedPassword(createUserDto.Password),
                Cpf = createUserDto.Cpf,
                BornDt = createUserDto.BornDt,
                RoleId = createUserDto.RoleId,
                Biography = createUserDto.Biography,
                UserImage = createUserDto.UserImage
            });

            await _context.SaveChangesAsync();

            return (new ResponseGeneric()
            {
                response = new ResponseViewModel(StatusCodes.Status201Created, "Usuário criado com sucesso!"),
                data = null
            });


        }
        catch (Exception ex)
        {
            return (new ResponseGeneric()
            {
                response = new ResponseViewModel()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Erro: {ex.Message}"
                },
                data = null
            });
        }
    }

    public async Task<ResponseGeneric> UpdateUser(UpdateUserDto updateUserDto)
    {
        try
        {
            var user = await _userQuery.GetUserByEmail(updateUserDto.Email);

            if (user == null)
                return (new ResponseGeneric()
                {
                    response = new ResponseViewModel(StatusCodes.Status400BadRequest, "Usuario não encontrado!"),
                    data = null
                });

            _context.Users.Update(new Domain.Models.User()
            {
                Fullname = updateUserDto.Fullname,
                Nickname = updateUserDto.Nickname,
                Email = updateUserDto.Email,
                Password = _encryptionService.GenerateHashedPassword(updateUserDto.Password),
                Cpf = updateUserDto.Cpf,
                BornDt = updateUserDto.BornDt,
                RoleId = updateUserDto.RoleId,
                Biography = updateUserDto.Biography,
                UserImage = updateUserDto.UserImage,
                Active = updateUserDto.Active
            });

            await _context.SaveChangesAsync();

            return (new ResponseGeneric()
            {
                response = new ResponseViewModel(StatusCodes.Status201Created, "Usuário atualizado com sucesso!"),
                data = null
            });


        }
        catch (Exception ex)
        {
            return (new ResponseGeneric()
            {
                response = new ResponseViewModel()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Erro: {ex.Message}"
                },
                data = null
            });
        }
    }
}