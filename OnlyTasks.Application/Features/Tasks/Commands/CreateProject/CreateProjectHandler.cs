using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken ct)
        {
            Project project = new Project(
                name: command.name,
                description: command.description
            );

            try
            {
                await _repository.CreateProjectAsync(project);
            }catch (Exception ex)
            {
                Console.WriteLine($"Failed to create project. Exception:{ex}");
                throw;
            }

            return project.Id;
        }
    }
}
