namespace Sample_Web_App.Features.Authors.Exceptions;

public class NoAuthorExistsException : Exception
{
    public NoAuthorExistsException(int authorId) : base($"Author with id: {authorId} doesn't exist.") { }
}
