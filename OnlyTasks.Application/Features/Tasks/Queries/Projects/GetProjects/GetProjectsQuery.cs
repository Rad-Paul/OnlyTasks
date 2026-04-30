using MediatR;
using OnlyTasks.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Queries.Projects.GetProjects
{
    public record GetProjectsQuery 
    (
        //userId
    ) : IRequest<IEnumerable<ProjectDto>>;
    
}
