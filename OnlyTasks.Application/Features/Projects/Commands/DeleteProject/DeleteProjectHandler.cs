using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository;
        public DeleteProjectHandler(IProjectRepository repository) 
        {
            _repository = repository;
        }
        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _repository.GetAsync(request.Id, request.IncludeTasks);

            if (project is null)
                throw new Exception("Project does not exist");

            await _repository.DeleteAsync(project, request.IncludeTasks);
        }
    }
}
