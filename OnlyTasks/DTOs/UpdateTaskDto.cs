namespace OnlyTasks.Api.Dtos
{
    public record UpdateTaskDto
    (
        Guid? ProjectId,
        string? Name,
        string? Description
    );
}
