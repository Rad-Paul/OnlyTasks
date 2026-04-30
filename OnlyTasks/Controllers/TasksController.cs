using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            Guid id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
