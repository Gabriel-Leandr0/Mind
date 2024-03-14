using AutoMapper;
using Mind.Domain.DTos;
using Mind.Domain.Models;

namespace Mind.Infrastructure.Profiles;

public class CategoryProfile : Profile
{
    //Constructor
    public CategoryProfile()
    {
        // Profile serve para mapear um objeto para outro
        // - CreateMap<ClasseOrigem, ClasseDestino>()
        // - ForMember(destino => destino.Propriedade, origem => origem.Propriedade)
        CreateMap<Category, ReadCategoryDto>();
        CreateMap<CreateCategoryDto, Category>();

    }
}
