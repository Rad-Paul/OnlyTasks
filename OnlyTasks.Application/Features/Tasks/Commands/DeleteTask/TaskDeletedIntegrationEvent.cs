using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.DeleteTask
{
    public class TaskDeletedIntegrationEvent
    {
        public Guid TaskId { get; init; }
        public TaskDeletedIntegrationEvent(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
