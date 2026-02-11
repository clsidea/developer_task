using Microsoft.AspNetCore.Identity;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class User : IdentityUser
    {
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
