using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand
    (
        Guid ProjectId,
        string? Name, 
        string? Description
    ) : IRequest;
}
