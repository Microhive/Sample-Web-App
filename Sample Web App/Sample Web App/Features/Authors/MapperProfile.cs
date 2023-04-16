using AutoMapper;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.Authors.CQRS;

namespace Sample_Web_App.Features.Authors;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, GetAllAuthors.AuthorResult>();
    }
}