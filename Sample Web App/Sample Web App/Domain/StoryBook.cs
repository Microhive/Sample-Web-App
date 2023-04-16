using System.ComponentModel.DataAnnotations;

namespace Sample_Web_App.Domain;

public class StoryBook
{
    [Key]
    public int StoryBookId { get; set; }
    
    public string Title { get; set; }

    public int AuthorId { get; set; }
    
    public Author Author { get; set; }
}