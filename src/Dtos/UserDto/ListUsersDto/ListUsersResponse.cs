namespace ShokanApi.Dtos.UserDto
{
    public class ListUsersResponse
    {
        public class Book
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
        }

        public required string Name { get; set; }
        public required IEnumerable<Book> BorrowedBooks { get; set; }
    }
}