using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTaskCommand request,  CancellationToken cancellationToken)
        {
            TaskItem? task = await _repository.GetTaskAsync(request.Id);

            if (task is null)
                throw new Exception("Task not found.");

            await _repository.DeleteTaskAsync(task);
        }
    }
}
