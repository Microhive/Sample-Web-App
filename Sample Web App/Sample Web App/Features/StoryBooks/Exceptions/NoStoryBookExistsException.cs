namespace Sample_Web_App.Features.StoryBooks.Exceptions;

public class NoStoryBookExistsException : Exception
{
    public NoStoryBookExistsException(int authorId, int storyBookId) : base($"StoryBook with id: {storyBookId} doesn't exist for author id {authorId}")
    {
        AuthorId = authorId;
        StoryBookId = storyBookId;
    }

    public int AuthorId { get; set; }
    public int StoryBookId { get; set; }
}