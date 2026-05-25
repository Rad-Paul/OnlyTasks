using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _repository.GetAsync(request.ProjectId, false);

            if (project is null)
                throw new Exception("Project not found.");

            if (request.Name is null && request.Description is null)
                throw new ArgumentException("No update data was provided.");

            project.ChangeName(request.Name);
            project.ChangeDescription(request.Description);

            await _repository.SaveChangesAsync(project);
        }
    }
}
