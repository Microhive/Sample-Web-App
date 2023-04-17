using Microsoft.EntityFrameworkCore;
using OneOf;
using Sample_Web_App.Data;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.Authors.Exceptions;

namespace Sample_Web_App.Features.Authors;

public class AuthorService : IAuthorService
{
    private readonly DataContext _context;

    public AuthorService(DataContext context)
    {
        _context = context;
    }

    public async Task<OneOf<IEnumerable<Author>>> GetAllAuthorsAsync()
    {
        return await _context.Authors
            .OrderBy(x => x.AuthorId)
            .ToListAsync();
    }
    
    public async Task<OneOf<Author, NoAuthorExistsException>> GetAuthorByIdAsync(int authorId)
    {
        var result = await _context.Authors
            .FirstOrDefaultAsync(x => x.AuthorId == authorId);
        
        if (result == null)
        {
            return new NoAuthorExistsException(authorId);
        }

        return result;
    }
}