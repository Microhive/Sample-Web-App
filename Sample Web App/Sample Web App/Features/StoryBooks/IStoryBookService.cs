using Sample_Web_App.Domain;

namespace Sample_Web_App.Features.StoryBooks;

public interface IStoryBookService
{
    Task<IEnumerable<StoryBook>> GetAllStoryBooksAsync(int authorId);
    Task<StoryBook> GetStoryBookAsync(int authorId, int storyBookId);
    void AddStoryBookToAuthor(int authorId, StoryBook storybook);
    void DeleteStoryBook(StoryBook storyBook);
}