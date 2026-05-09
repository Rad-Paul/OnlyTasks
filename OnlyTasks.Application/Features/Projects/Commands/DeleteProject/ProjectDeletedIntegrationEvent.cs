using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.DeleteProject
{
    public class ProjectDeletedIntegrationEvent
    {
        public Guid ProjectId { get; }
        public ProjectDeletedIntegrationEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
