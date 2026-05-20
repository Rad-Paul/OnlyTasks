using MediatR;
using OnlyTasks.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Queries.GetProject
{
    public record GetProjectQuery
    (
        Guid ProjectId,
        bool IncludeTasks
    ) : IRequest<ProjectDto>;
    
}
