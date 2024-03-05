using System.Threading.Tasks;
using Mind.Application.Interfaces;
using Mind.Domain.DTos;
using Mind.Domain.ViewModels;
using Mind.Read.Interface;

namespace Mind.Application.Services;

public class UserService : IUserService
{
    Task<ResponseGeneric> IUserService.CreateUser(CreateUserDto createUserDto)
    {
        throw new System.NotImplementedException();
    }
}