using MediatR;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Queries.GetProject
{
    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IProjectRepository _repository;
        public GetProjectHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            Project? project = await _repository.GetAsync(request.ProjectId, request.IncludeTasks);

            if (project is null)
                throw new Exception("Project not found.");

            ProjectDto projectDto = ProjectDto.EntityToDto(project);

            return projectDto;
        }
    }
}
