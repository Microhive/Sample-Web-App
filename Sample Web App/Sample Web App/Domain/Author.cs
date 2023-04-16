namespace Sample_Web_App.Domain;

public class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<StoryBook> StoryBooks { get; set; }
}