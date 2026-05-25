using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Projects.Commands.UpdateProject
{
    public class ProjectUpdatedHandler : INotificationHandler<ProjectUpdatedDomainEvent>
    {
        private readonly IMessageBus _messageBus;
        public ProjectUpdatedHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(ProjectUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageBus.PublishAsync(new ProjectUpdatedIntegrationEvent(notification.ProjectId));
        }
    }
}
