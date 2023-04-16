using AutoMapper;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.Authors.CQRS;
using Sample_Web_App.Features.StoryBooks.CQRS;

namespace Sample_Web_App.Features.StoryBooks;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<StoryBook, AddStoryBookToAuthor.StoryBookResult>();
        CreateMap<StoryBook, GetAllStoryBooksForAuthor.StoryBookResult>();
        CreateMap<StoryBook, UpdateStoryBookForAuthor.UpdateStoryBookResult>();
    }
}