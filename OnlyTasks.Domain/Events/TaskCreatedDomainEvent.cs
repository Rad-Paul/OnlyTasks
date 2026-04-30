using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Events
{
    public class TaskCreatedDomainEvent : INotification
    {
        public Guid TaskId { get; }
        public TaskCreatedDomainEvent(Guid taskId)
        {
            TaskId = taskId;
        }
    }
}
