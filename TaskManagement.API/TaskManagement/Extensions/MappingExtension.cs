using TaskManagement.DTOs;
using TaskManagement.Models;

namespace TaskManagement.Extensions
{
    public static class MappingExtension
    {
        public static AuthResponseDto ToAuthDto(this string token)
        {
            return new AuthResponseDto
            {
                Token = token
            };
        }

        public static TaskResponseDto ToDto(this TaskItem task)
        {
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                DueDate = task.DueDate,
                CreatedAt = task.CreatedAt
            };
        }


        public static TaskItem ToEntity(this TaskCreateDto dto, Guid userId)
        {
            return new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Status = Models.Enums.TaskStatus.Pending,
                DueDate = dto.DueDate,
                UserId = userId.ToString()
            };
        }
    }
}
