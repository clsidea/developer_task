using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByUserIdAsync(Guid userId)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId.ToString())
                .Include(t => t.TaskEvents)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid taskId)
        {
            return await _context.Tasks
                .Include(t => t.TaskEvents)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task AddTaskEventAsync(TaskEvent taskEvent)
        {
            _context.TaskEvents.Add(taskEvent);
            await _context.SaveChangesAsync();
        }
    }
}
