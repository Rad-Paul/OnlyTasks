using MediatR;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;

namespace OnlyTasks.Application.Features.Projects.Queries.GetProjects
{
    public class GetProjectsHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _repository;
        public GetProjectsHandler(IProjectRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Project> projects = await _repository.GetAllAsync();

            List<ProjectDto> projectDtos = projects.Select(p => ProjectDto.EntityToDto(p))
                .ToList();

            return projectDtos;
        }
    }

}
