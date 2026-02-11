using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<AuthResponseDto> Register([FromBody] RegisterDto dto)
        {
            return await _authService.RegisterAsync(dto);
        }

        [HttpPost("login")]
        public async Task<AuthResponseDto> Login([FromBody] LoginDto dto)
        {
            return await _authService.LoginAsync(dto);
        }
    }
}
