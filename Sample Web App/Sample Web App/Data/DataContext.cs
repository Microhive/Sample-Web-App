using Microsoft.EntityFrameworkCore;
using Sample_Web_App.Domain;

namespace Sample_Web_App.Data;

public class DataContext : DbContext
{
    public DbSet<StoryBook> StoryBooks { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
}