using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.DTOs
{
    public record TaskItemDto
    (
        Guid Id,
        string Name,
        string Description,
        TaskStatus Status
    );   
}
