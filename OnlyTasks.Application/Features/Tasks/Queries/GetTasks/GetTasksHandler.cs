using MediatR;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;

namespace OnlyTasks.Application.Features.Tasks.Queries.GetTasks
{
    public class GetTasksHandler : IRequestHandler<GetTasksQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ITaskRepository _repository;
        public GetTasksHandler(ITaskRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItemDto>> Handle(GetTasksQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<TaskItem> tasks = await _repository.GetTasksAsync(query.ProjectId, query.Status);

            List<TaskItemDto> taskDtos = tasks.Select(t => new TaskItemDto 
            { 
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = (TaskStatus)t.Status
            }).ToList();

            return taskDtos;
        }
    }
    
}
