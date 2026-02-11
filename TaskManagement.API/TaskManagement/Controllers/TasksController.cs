using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.DTOs;
using TaskManagement.Services;

namespace TaskManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private Guid GetUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpPost]
        public async Task<TaskResponseDto> Create([FromBody] TaskCreateDto dto)
        {
            return await _taskService.CreateTaskAsync(dto, GetUserId());
        }

        [HttpGet]
        public async Task<IEnumerable<TaskResponseDto>> GetUserTasks()
        {
            return await _taskService.GetUserTasksAsync(GetUserId());
        }

        [HttpPatch("{id}/status")]
        public async Task<TaskResponseDto> UpdateStatus(Guid id, [FromQuery] string status)
        {
            return await _taskService.UpdateStatusAsync(id, status, GetUserId());
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _taskService.DeleteTaskAsync(id, GetUserId());
        }
    }
}
