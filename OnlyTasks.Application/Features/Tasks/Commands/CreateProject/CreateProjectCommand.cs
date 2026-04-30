using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateProject
{
    public record CreateProjectCommand(
        string Name, 
        string Description
    ) : IRequest<Guid>;
}
