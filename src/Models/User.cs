using ShokanApi.Utils;

namespace ShokanApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required TypeUser Type { get; set; }
        public string? Password { get; set; }
        public List<Book>? BorrowedBooks { get; set; }
    }
}