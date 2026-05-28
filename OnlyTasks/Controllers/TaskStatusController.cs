using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.Tasks.Commands.ChangeTaskStatus;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

namespace OnlyTasks.Api.Controllers
{
    [ApiController]
    [Route("api/tasks/{id:guid}/status")]
    public class TaskStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            await _mediator.Send(new ChangeTaskStatusCommand(id, TaskStatus.Completed));
            return NoContent();
        }

        [HttpPut("ongoing")]
        public async Task<IActionResult> OnGoing(Guid id)
        {
            await _mediator.Send(new ChangeTaskStatusCommand(id, TaskStatus.Ongoing));
            return NoContent();
        }

        [HttpPut("fail")]
        public async Task<IActionResult> Fail(Guid id)
        {
            await _mediator.Send(new ChangeTaskStatusCommand(id, TaskStatus.Failed));
            return NoContent();
        }
    }
}
