using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnlyTasks.Domain.Events
{
    public class TaskStatusChangedDomainEvent : INotification
    {
        public Guid TaskId { get; init; }
        public TaskStatus Previous { get; init; }
        public TaskStatus NewStatus { get; init; }

        public TaskStatusChangedDomainEvent(Guid taskId, TaskStatus previous, TaskStatus newStatus)
        {
            TaskId = taskId;
            Previous = previous;
            NewStatus = newStatus;
        }
    }
}
