using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Events
{
    public class ProjectUpdatedDomainEvent : INotification
    {
        public Guid ProjectId { get; }

        public ProjectUpdatedDomainEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
