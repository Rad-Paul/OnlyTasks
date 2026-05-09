using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.DeleteProject
{
    public class ProjectDeletedEventHandler : INotificationHandler<ProjectDeletedDomainEvent>
    {
        private readonly IMessageBus _messageBus;
        public ProjectDeletedEventHandler(IMessageBus messageBus) 
        { 
            _messageBus = messageBus;
        }

        public async Task Handle(ProjectDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageBus.PublishAsync(
                new ProjectDeletedIntegrationEvent(notification.ProjectId)
            );
        }
    }
}
