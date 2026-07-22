using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfume.Api.Data;
using Perfume.Api.Dtos;
using Perfume.Api.Models;
using Perfume.Api.Services;

namespace Perfume.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(AppDbContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            var exists = await _context.Users.AnyAsync(u => u.Username == registerDto.UserName);
            if (exists)
                return BadRequest("Username already taken");
            var paswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var user = new User { Username = registerDto.UserName, PasswordHash = paswordHash, Role = "User" };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registerd successfully");

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginDto dto)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Username == dto.Username);
            if (user is null)
                return Unauthorized("Invalid username or password");
            var valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!valid)
                return Unauthorized("Invalid username or password");
            var token = _tokenService.CreateToken(user);

            return Ok(new {token});

        }
    }
}
