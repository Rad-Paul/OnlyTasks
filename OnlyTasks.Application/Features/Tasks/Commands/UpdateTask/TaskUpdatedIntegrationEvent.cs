using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.UpdateTask
{
    public class TaskUpdatedIntegrationEvent
    {
        public Guid TaskId { get; }
        public TaskUpdatedIntegrationEvent(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
