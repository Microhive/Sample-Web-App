using Microsoft.EntityFrameworkCore;
using OneOf;
using Sample_Web_App.Data;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.StoryBooks.Exceptions;

namespace Sample_Web_App.Features.StoryBooks;

public class StoryBookService : IStoryBookService
{
    private readonly DataContext _context;

    public StoryBookService(DataContext context)
    {
        _context = context;
    }

    public void AddStoryBookToAuthor(int authorId, StoryBook storyBook)
    {
        storyBook.AuthorId = authorId;

        _context.StoryBooks.Add(storyBook);
    }

    public void DeleteStoryBook(StoryBook storyBook)
    {
        _context.StoryBooks.Remove(storyBook);
    }

    public async Task<OneOf<IEnumerable<StoryBook>, NoAuthorExistsException>> GetAllStoryBooksAsync(int authorId)
    {
        return await _context.StoryBooks
            .Where(x => x.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<OneOf<StoryBook, NoAuthorExistsException, NoStoryBookExistsException>> GetStoryBookAsync(int authorId, int storyBookId)
    {
        var authorResult = await _context.Authors
            .FirstOrDefaultAsync(x => x.AuthorId == authorId);
        
        if (authorResult == null)
        {
            return new NoAuthorExistsException(authorId);
        }
            
        var storyResult = await _context.StoryBooks
            .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.StoryBookId == storyBookId);

        if (storyResult == null)
        {
            return new NoStoryBookExistsException(authorId, storyBookId);
        }

        return storyResult;
    }
}