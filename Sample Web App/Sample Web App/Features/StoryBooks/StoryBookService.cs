using Sample_Web_App.Data;

namespace Sample_Web_App.Features.StoryBooks;

public class StoryBookService : IStoryBookService
{
    private readonly DataContext _context;

    public StoryBookService(DataContext context)
    {
        _context = context;
    }
}