using Microsoft.AspNetCore.Mvc;
using CenevalApp.Models;
using CenevalApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CenevalApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest(new { message = "Usuario y contraseña son requeridos." });

            var exists = await _context.Users.AnyAsync(u => u.Username == dto.Username);
            if (exists)
                return Conflict(new { message = "El nombre de usuario ya existe." });

            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password, // Prueba de concepto - en producción usar hash
                FullName = dto.FullName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuario registrado exitosamente.", userId = user.Id, username = user.Username });
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == dto.Username && u.Password == dto.Password);

            if (user == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            return Ok(new
            {
                message = "Login exitoso.",
                userId = user.Id,
                username = user.Username,
                fullName = user.FullName
            });
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new { u.Id, u.Username, u.FullName })
                .ToListAsync();

            return Ok(users);
        }
    }

    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
