using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using OnlyTasks.Application.Features.Tasks.Queries.GetTasks;

namespace OnlyTasks.Api.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/tasks")]
    public class ProjectTasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectTasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasksForProject([FromQuery]GetTasksQuery query, Guid projectId)
        {
            IEnumerable<TaskItemDto> tasks = await _mediator.Send(new GetTasksQuery(projectId, query.Status));
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskForProject(CreateTaskCommand command, Guid projectId)
        {
            Guid id = await _mediator.Send(new CreateTaskCommand(command.Name, command.Description, projectId));
            return Created();
        }

    }
}
