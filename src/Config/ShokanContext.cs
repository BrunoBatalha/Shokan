using Microsoft.EntityFrameworkCore;
using ShokanApi.Models;
using ShokanApi.Utils;

public class ShokanContext : DbContext
{
    public ShokanContext(DbContextOptions<ShokanContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(e => e.Type)
            .HasConversion(
                v => v.ToString(),
                v => (TypeUser)Enum.Parse(typeof(TypeUser), v)
            );
    }
    public required DbSet<Book> Books { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<Loan> Loans { get; set; }
}