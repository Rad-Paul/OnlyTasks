using OnlyTasks.Domain.Entities;

namespace OnlyTasks.Api.DTOs
{
    public record UpdateProjectDto
    (
        string? Name,
        string? Description
    );
}
