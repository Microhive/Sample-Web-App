using Sample_Web_App.Data;
using Sample_Web_App.Features.Authors;
using Sample_Web_App.Features.StoryBooks;

namespace Sample_Web_App.ServiceManager;

public class ServiceManager : IServiceManager
{
    private readonly DataContext _context;
    private IStoryBookService _storyBookService;
    private IAuthorService _authorService;
    
    public ServiceManager(DataContext context)
    {
        _context = context;
    }
    public IStoryBookService StoryBook
    {
        get
        {
            if (_storyBookService == null)
                _storyBookService = new StoryBookService(_context);
            return _storyBookService;
        }
    }
    public IAuthorService Author
    {
        get
        {
            if (_authorService == null)
                _authorService = new AuthorService(_context);
            return _authorService;
        }
    }
    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}