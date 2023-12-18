using Microsoft.EntityFrameworkCore;

public class ShokanContext : DbContext
{
    public ShokanContext(DbContextOptions<ShokanContext> options) : base(options)
    {
    }
    
    public required DbSet<Book> Books { get; set; }
}