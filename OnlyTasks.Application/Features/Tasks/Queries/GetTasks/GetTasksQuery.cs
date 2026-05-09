using MediatR;
using OnlyTasks.Application.Features.DTOs;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

namespace OnlyTasks.Application.Features.Tasks.Queries.GetTasks
{
    public record GetTasksQuery
    (
        Guid? ProjectId,
        TaskStatus Status = TaskStatus.Ongoing
        //userId
    ) : IRequest<IEnumerable<TaskItemDto>>;
}
