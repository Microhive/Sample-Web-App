using Microsoft.EntityFrameworkCore;
using Sample_Web_App.Data;
using Sample_Web_App.Domain;

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

    public async Task<IEnumerable<StoryBook>> GetAllStoryBooksAsync(int authorId)
    {
        return await _context.StoryBooks
            .Where(x => x.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<StoryBook> GetStoryBookAsync(int authorId, int storyBookId)
    {
        return await _context.StoryBooks
            .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.StoryBookId == storyBookId);
    }
}