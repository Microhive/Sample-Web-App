namespace Sample_Web_App.Domain;

public class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; }

    public ICollection<StoryBook> StoryBooks { get; set; }
}