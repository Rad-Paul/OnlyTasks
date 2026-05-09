using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Events
{
    public class ProjectDeletedDomainEvent : INotification
    {
        public Guid ProjectId { get; init; }
        public ProjectDeletedDomainEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
