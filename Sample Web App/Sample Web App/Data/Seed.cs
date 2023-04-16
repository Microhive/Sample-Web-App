using Sample_Web_App.Domain;

namespace Sample_Web_App.Data;

public class Seed
{
    public void SeedData(DataContext context)
    {
        //Seeding Authors
        context.Authors.Add(new Author
        {
            AuthorId = 1,
            Name = "Hehlenae",
        });
        context.Authors.Add(new Author
        {
            AuthorId = 2,
            Name = "Reighler",
        });

        // Seeding Story Books
        context.StoryBooks.Add(
            new StoryBook
            {
                StoryBookId = 1,
                Title = "Alda og Brim",
                AuthorId = 1
            }
        );
        context.StoryBooks.Add(
            new StoryBook
            {
                StoryBookId = 2,
                Title = "The Hare",
                AuthorId = 1
            }
        );
        context.StoryBooks.Add(
            new StoryBook
            {
                StoryBookId = 3,
                Title = "Best friends: Sir Bearington and the Salmon",
                AuthorId = 2
            }
        );
        
        context.SaveChanges();
    }
}