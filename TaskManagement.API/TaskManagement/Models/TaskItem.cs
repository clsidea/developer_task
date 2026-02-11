using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.Pending;

        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public string UserId { get; set; } = null!; 

  
        public User User { get; set; } = null!;

        public ICollection<TaskEvent> TaskEvents { get; set; } = new List<TaskEvent>();
    }
}
