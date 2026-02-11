using Microsoft.AspNetCore.Identity;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterAsync(User user, string password);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<bool> UserExistsAsync(string email);
    }
}
