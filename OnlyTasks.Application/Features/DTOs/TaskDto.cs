using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.DTOs
{
    public class TaskItemDto
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required TaskStatus Status { get; init; }
    };   
}
