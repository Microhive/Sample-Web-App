using Microsoft.EntityFrameworkCore;
using Sample_Web_App.Data;
using Sample_Web_App.Domain;

namespace Sample_Web_App.Features.Authors;

public class AuthorService : IAuthorService
{
    private readonly DataContext _context;

    public AuthorService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors
            .OrderBy(x => x.AuthorId)
            .ToListAsync();
    }
    
    public async Task<Author> GetAuthorByIdAsync(int authorId)
    {
        return await _context.Authors
            .FirstOrDefaultAsync(x => x.AuthorId == authorId);
    }
}