using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateProject
{
    public class ProjectCreatedIntegrationEvent
    {
        public Guid ProjectId { get; }
        public ProjectCreatedIntegrationEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
