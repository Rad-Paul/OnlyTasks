using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.UpdateTask
{
    public record UpdateTaskCommand
    (
        Guid TaskId,
        Guid? ProjectId,
        string? Name,
        string? Description
    ) : IRequest;
    
}
