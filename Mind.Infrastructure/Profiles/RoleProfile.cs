using AutoMapper;
using Mind.Domain.DTos;
using Mind.Domain.Models;

namespace Mind.Infrastructure.Profiles;

public class RoleProfile : Profile
{  
    //Constructor
    public RoleProfile()
    {
        // Profile serve para mapear um objeto para outro
            // - CreateMap<ClasseOrigem, ClasseDestino>()
            // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<Role, ReadRoleDto>();
        CreateMap<CreateRoleDto, Role>();
        
    }
}
