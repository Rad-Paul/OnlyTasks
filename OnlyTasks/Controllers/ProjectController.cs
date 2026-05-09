using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Application.Features.Projects.Commands.CreateProject;
using OnlyTasks.Application.Features.Projects.Commands.DeleteProject;
using OnlyTasks.Application.Features.Projects.Queries.GetProjects;
using OnlyTasks.Domain.Entities;
using System.Net;

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
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProjectDto> projects = await _mediator.Send(new GetProjectsQuery());
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery]bool? includeTasks, Guid id)
        {
            await _mediator.Send(new DeleteProjectCommand(id, includeTasks ?? false));
            return NoContent();
        }
    }
}
