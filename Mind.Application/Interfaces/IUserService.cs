using System.Threading.Tasks;
using Mind.Domain.DTos;
using Mind.Domain.DTos.User;
namespace Mind.Application.Interfaces;

public interface IUserService
{
    public Task<ResponseGeneric> CreateUser(CreateUserDto createUserDto);
    public Task<ResponseGeneric> UpdateUser(UpdateUserDto updateUserDto);
    
}