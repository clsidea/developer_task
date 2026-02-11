using TaskManagement.DTOs;
using TaskManagement.Extensions;
using TaskManagement.Helpers;
using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtTokenGenerator _jwtGenerator;

        public AuthService(IAuthRepository authRepository, JwtTokenGenerator jwtGenerator)
        {
            _authRepository = authRepository;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            if (await _authRepository.UserExistsAsync(dto.Email))
                throw new ApplicationException("User already exists");

            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _authRepository.RegisterAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            var token = _jwtGenerator.GenerateToken(user);
            return token.ToAuthDto();
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _authRepository.GetUserByEmailAsync(dto.Email);

            if (user == null || !await _authRepository.CheckPasswordAsync(user, dto.Password))
                throw new ApplicationException("Invalid email or password");

            var token = _jwtGenerator.GenerateToken(user);
            return token.ToAuthDto();
        }
    }
}
