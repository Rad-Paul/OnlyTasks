using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand
    (
        Guid Id,
        bool IncludeTasks
    ) : IRequest;
}
