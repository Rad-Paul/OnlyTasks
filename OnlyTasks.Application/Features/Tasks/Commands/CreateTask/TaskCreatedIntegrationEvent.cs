using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateTask
{
    public class TaskCreatedIntegrationEvent
    {
        public Guid TaskId { get; init; }
        public TaskCreatedIntegrationEvent(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
