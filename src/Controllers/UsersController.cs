using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShokanApi.Dtos.UserDto;
using ShokanApi.Models;
using ShokanApi.Utils;

namespace ShokanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ShokanContext _context;

        public UsersController(ShokanContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListUsersResponse>>> ListUsers()
        {
            List<User> users = await _context.Users.Include(u => u.BorrowedBooks).ToListAsync();

            return users.ToList().Select(u => new ListUsersResponse
            {
                BorrowedBooks = u.BorrowedBooks!.Select(b => new ListUsersResponse.Book
                {
                    Id = b.Id,
                    Name = b.Name
                }),
                Name = u.Name
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Type = TypeUser.Common,
                Password = userDto.Password
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, new CreateUserResponse { Name = user.Name });
        }
    }
}
