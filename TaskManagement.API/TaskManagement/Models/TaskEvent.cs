namespace TaskManagement.Models
{
    public class TaskEvent
    {
        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        public string UserId { get; set; } = null!;

        public string Type { get; set; } = "TASK_COMPLETED";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public TaskItem Task { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
