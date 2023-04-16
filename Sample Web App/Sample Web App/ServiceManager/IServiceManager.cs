using Sample_Web_App.Features.Authors;
using Sample_Web_App.Features.StoryBooks;

namespace Sample_Web_App.ServiceManager;

public interface IServiceManager
{
    IStoryBookService StoryBook { get; }
    IAuthorService Author { get; }
    Task SaveAsync();
}