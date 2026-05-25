using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Api.DTOs;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Application.Features.Projects.Commands.CreateProject;
using OnlyTasks.Application.Features.Projects.Commands.DeleteProject;
using OnlyTasks.Application.Features.Projects.Commands.UpdateProject;
using OnlyTasks.Application.Features.Projects.Queries.GetProject;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromQuery]bool? includeTasks, Guid id)
        {
            ProjectDto project = await _mediator.Send(new GetProjectQuery(id, includeTasks ?? false));
            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProjectDto> projects = await _mediator.Send(new GetProjectsQuery());
            return Ok(projects);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(UpdateProjectDto data, Guid id)
        {
            await _mediator.Send(new UpdateProjectCommand(id, data.Name, data.Description));
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromQuery]bool? includeTasks, Guid id)
        {
            await _mediator.Send(new DeleteProjectCommand(id, includeTasks ?? false));
            return NoContent();
        }

    }
}
