using AutoMapper;
using Mind.Domain.DTos;
using Mind.Domain.Models;

namespace Mind.Infrastructure.Profiles;

public class UserProfile : Profile
{
    //Constructor
    public UserProfile()
    {
        // Profile serve para mapear um objeto para outro
        // - CreateMap<ClasseOrigem, ClasseDestino>()
        // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<User, ReadUserDto>()
            .ForMember(ReadUserDto => ReadUserDto.RoleId,
                opt => opt.MapFrom(User => User.RoleId));

        CreateMap<CreateUserDto, User>();

    }
}
