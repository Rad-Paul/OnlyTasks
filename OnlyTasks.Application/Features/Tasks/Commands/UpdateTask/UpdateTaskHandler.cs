using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTaskCommand command, CancellationToken cancellationToken)
        {
            TaskItem? task = await _repository.GetTaskAsync(command.TaskId);

            if (task is null)
                throw new Exception("Task not found.");

            task.UpdateTask(command.ProjectId, command.Name, command.Description);

            await _repository.SaveChangesAsync(task);
        }
    }
}
