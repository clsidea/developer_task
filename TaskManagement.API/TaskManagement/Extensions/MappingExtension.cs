using TaskManagement.DTOs;

namespace TaskManagement.Extensions
{
    public static class MappingExtension
    {
        public static AuthResponseDto ToAuthDto(this string token)
        {
            return new AuthResponseDto
            {
                Token = token
            };
        }
    }
}
