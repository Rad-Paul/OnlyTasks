using MediatR;
using OnlyTasks.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlyTasks.Application.Features.Tasks.Commands.ChangeTaskStatus
{
    public record ChangeTaskStatusCommand
    (
        Guid TaskId, 
        Domain.Enums.TaskStatus Status
    ) : IRequest;
    
}
