using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using OnlyTasks.Domain.Events;
using OnlyTasks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken token)
        {
            TaskItem task = new TaskItem(
                title: request.Title,
                description: request.Description,
                projectId: request.ProjectId
            );

            try
            {
                await _repository.CreateTaskAsync(task);
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Failed to create task. Exception: {ex}");
                throw;
            }

            return task.Id;
        }
    }
}
