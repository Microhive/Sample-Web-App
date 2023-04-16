namespace Sample_Web_App.Domain;

public class StoryBook
{
    public int StoryBookId { get; set; }
    
    public string Title { get; set; }

    public Author Author { get; set; }
}