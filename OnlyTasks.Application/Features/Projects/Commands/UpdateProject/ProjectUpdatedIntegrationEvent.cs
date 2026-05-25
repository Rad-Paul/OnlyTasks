using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.UpdateProject
{
    public class ProjectUpdatedIntegrationEvent
    {
        public Guid ProjectId { get; }
        public ProjectUpdatedIntegrationEvent(Guid projectId)
        {
            ProjectId = projectId;
        }
    }
}
