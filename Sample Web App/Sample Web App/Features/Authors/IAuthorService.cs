using OneOf;
using OneOf.Types;
using Sample_Web_App.Domain;
using Sample_Web_App.Features.Authors.Exceptions;

namespace Sample_Web_App.Features.Authors;

public interface IAuthorService
{
    Task<OneOf<IEnumerable<Author>>> GetAllAuthorsAsync();
    Task<OneOf<Author, NoAuthorExistsException>> GetAuthorByIdAsync(int authorId);
}