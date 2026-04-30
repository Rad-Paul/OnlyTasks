using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Events
{
    public class ProjectCreatedDomainEvent : INotification
    {
        public Guid ProjectId { get; }

        public ProjectCreatedDomainEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
