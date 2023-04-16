using Sample_Web_App.Domain;

namespace Sample_Web_App.Features.Authors;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author> GetAuthorByIdAsync(int authorId);
}