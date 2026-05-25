using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlyTasks.Api.Dtos;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using OnlyTasks.Application.Features.Tasks.Commands.DeleteTask;
using OnlyTasks.Application.Features.Tasks.Commands.UpdateTask;
using OnlyTasks.Application.Features.Tasks.Queries.GetTask;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            TaskItemDto task = await _mediator.Send(new GetTaskQuery(id));
            return Ok(task);
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTaskCommand(id));
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(UpdateTaskDto data, Guid id)
        {
            await _mediator.Send(new UpdateTaskCommand(id, data.ProjectId, data.Name, data.Description));
            return NoContent();
        }
    }
}
