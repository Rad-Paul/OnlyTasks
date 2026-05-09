using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using OnlyTasks.Application.Features.Tasks.Queries.GetTasks;

namespace OnlyTasks.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery]GetTasksQuery query)
        {
            IEnumerable<TaskItemDto> tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            Guid id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
