using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTOs
{
    public class TaskCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
