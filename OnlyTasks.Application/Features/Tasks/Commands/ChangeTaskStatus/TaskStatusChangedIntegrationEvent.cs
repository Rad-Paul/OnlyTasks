using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

namespace OnlyTasks.Application.Features.Tasks.Commands.ChangeTaskStatus
{
    public class TaskStatusChangedIntegrationEvent : INotification
    {
        public Guid TaskId { get; init; }
        public TaskStatus Previous { get; init; }
        public TaskStatus NewStatus { get; init; }
        public TaskStatusChangedIntegrationEvent(Guid taskId, TaskStatus previous, TaskStatus newStatus)
        {
            TaskId = taskId;
            Previous = previous;
            NewStatus = newStatus;
        }
    }
}
