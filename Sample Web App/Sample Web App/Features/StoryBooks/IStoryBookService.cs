using Sample_Web_App.Domain;
using OneOf;
using Sample_Web_App.Features.StoryBooks.Exceptions;

namespace Sample_Web_App.Features.StoryBooks;

public interface IStoryBookService
{
    Task<OneOf<IEnumerable<StoryBook>, NoAuthorExistsException>> GetAllStoryBooksAsync(int authorId);
    Task<OneOf<StoryBook, NoAuthorExistsException, NoStoryBookExistsException>> GetStoryBookAsync(int authorId, int storyBookId);
    void AddStoryBookToAuthor(int authorId, StoryBook storybook);
    void DeleteStoryBook(StoryBook storyBook);
}