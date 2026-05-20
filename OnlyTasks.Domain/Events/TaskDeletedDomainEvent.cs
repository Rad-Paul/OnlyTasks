using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Events
{
    public class TaskDeletedDomainEvent : INotification
    {
        public Guid TaskId { get; init; }

        public TaskDeletedDomainEvent(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
