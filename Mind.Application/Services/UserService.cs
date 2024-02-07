using System.Threading.Tasks;
using Mind.Application.Interfaces;
using Mind.Domain.DTos;
using Mind.Domain.ViewModels;

namespace Mind.Application.Services;

public class UserService : IUserService
{
    public readonly IUserQue

    Task<ResponseGeneric> IUserService.CreateUser(CreateUserViewModel createUserViewModel)
    {
        throw new System.NotImplementedException();
    }
}