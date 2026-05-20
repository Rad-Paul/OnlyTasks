using OnlyTasks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.DTOs
{
    public class ProjectDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required DateTime CreationDate { get; init; }
        public IEnumerable<TaskItemDto>? Tasks { get; init; }

        public static ProjectDto EntityToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreationDate = project.CreationDate,
                Tasks = project.Tasks?.Select(t => TaskItemDto.EntityToDto(t)).ToList()
            };
        }
    };

}
