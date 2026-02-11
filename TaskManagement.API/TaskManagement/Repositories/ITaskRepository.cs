using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(Guid userId);
        Task<TaskItem?> GetByIdAsync(Guid taskId);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(TaskItem task);
        Task AddTaskEventAsync(TaskEvent taskEvent);
    }
}
