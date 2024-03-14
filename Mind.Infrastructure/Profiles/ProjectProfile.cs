using AutoMapper;
using Mind.Domain.DTos;
using Mind.Domain.Models;

namespace Mind.Infrastructure.Profiles;

public class ProjectProfile : Profile
{
    //Constructor
    public ProjectProfile()
    {
        // Profile serve para mapear um objeto para outro
        // - CreateMap<ClasseOrigem, ClasseDestino>()
        // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<Project, ReadProjectDto>()
            .ForMember(ReadProjectDto => ReadProjectDto.CategoryId,
                opt => opt.MapFrom(Project => Project.CategoryId));
        CreateMap<CreateProjectDto, Project>();

    }
}
