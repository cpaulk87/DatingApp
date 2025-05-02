using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class UsersController(DataContext context, ILogger<UsersController> logger) : BaseApiController
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<UsersController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            _logger.LogInformation("Getting all users");
            List<AppUser> users = await _context.Users.ToListAsync();
            _logger.LogInformation("Number of users retrieved: {Count}", users.Count);
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            _logger.LogInformation("Getting user with ID: {Id}", id);
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID: {Id} not found", id);
                return NotFound();
            }
            _logger.LogInformation("User with ID: {Id} retrieved", id);
            return Ok(user);
        }

        [HttpPost]
        public void CreateUser([FromBody] string user)
        {
            // Logic to create a user
        }

        [HttpPut("{id}")]
        public void UpdateUser(int id, [FromBody] string user)
        {
            // Logic to update a user
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            // Logic to delete a user
        }
    }
}
