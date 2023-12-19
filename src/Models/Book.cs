namespace ShokanApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Borrowed { get; set; }
        public int? LenderId { get; set; }
        public User? Lender { get; set; }
    }
}