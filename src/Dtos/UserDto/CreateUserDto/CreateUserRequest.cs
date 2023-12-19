namespace ShokanApi.Dtos.UserDto
{
    public class CreateUserRequest
    {
        public required string Name { get; set; }
        public string? Password { get; set; }
    }
}