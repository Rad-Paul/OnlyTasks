using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.Tasks.Commands.CreateProject;

namespace OnlyTasks.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            Guid id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
