using TaskManagement.DTOs;

namespace TaskManagement.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTaskAsync(TaskCreateDto dto, Guid userId);
        Task<IEnumerable<TaskResponseDto>> GetUserTasksAsync(Guid userId);
        Task<TaskResponseDto> UpdateStatusAsync(Guid taskId, string status, Guid userId);
        Task DeleteTaskAsync(Guid taskId, Guid userId);
    }
}
