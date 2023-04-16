namespace Sample_Web_App.Features.StoryBooks.Exceptions;

public class NoAuthorExistsException : Exception
{
    public NoAuthorExistsException(int authorId) : base($"Author with id: {authorId} doesn't exist.") { }
}
