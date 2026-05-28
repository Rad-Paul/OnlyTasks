using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.ChangeTaskStatus
{
    public class ChangeTaskStatusHandler : IRequestHandler<ChangeTaskStatusCommand>
    {
        private readonly ITaskRepository _repository;
        public ChangeTaskStatusHandler(ITaskRepository taskRepository)
        {
            _repository = taskRepository;
        }

        public async Task Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            TaskItem? task = await _repository.GetTaskAsync(request.TaskId);

            if (task is null)
                throw new Exception("Task not found.");

            task.ChangeStatus(request.Status);

            await _repository.SaveChangesAsync(task);
        }
    }
}
