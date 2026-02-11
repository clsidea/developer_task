using TaskManagement.DTOs;
using TaskManagement.Extensions;
using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskResponseDto> CreateTaskAsync(TaskCreateDto dto, Guid userId)
        {
            var task = dto.ToEntity(userId);
            var createdTask = await _repository.CreateAsync(task);
            return createdTask.ToDto();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetUserTasksAsync(Guid userId)
        {
            var tasks = await _repository.GetTasksByUserIdAsync(userId);
            return tasks.Select(t => t.ToDto());
        }

        public async Task<TaskResponseDto> UpdateStatusAsync(Guid taskId, string status, Guid userId)
        {
            var task = await _repository.GetByIdAsync(taskId)
                       ?? throw new KeyNotFoundException("Task not found");

            if (task.UserId != userId.ToString())
                throw new UnauthorizedAccessException("Cannot update another user's task");

            if (!Enum.TryParse<Models.Enums.TaskStatus>(status, true, out var newStatus))
                throw new ApplicationException("Invalid status value");

            task.Status = newStatus;
            await _repository.UpdateAsync(task);

          
            if (newStatus == Models.Enums.TaskStatus.Completed)
            {
                var taskEvent = new TaskEvent
                {
                    TaskId = task.Id,
                    UserId = userId.ToString(),
                    Type = "TASK_COMPLETED"
                };
                await _repository.AddTaskEventAsync(taskEvent);
            }

            return task.ToDto();
        }

        public async Task DeleteTaskAsync(Guid taskId, Guid userId)
        {
            var task = await _repository.GetByIdAsync(taskId)
                       ?? throw new KeyNotFoundException("Task not found");

            if (task.UserId != userId.ToString())
                throw new UnauthorizedAccessException("Cannot delete another user's task");

            await _repository.DeleteAsync(task);
        }
    }
}
