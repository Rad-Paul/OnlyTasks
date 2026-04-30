using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateProject
{
    public class ProjectCreatedEventHandler : INotificationHandler<ProjectCreatedDomainEvent>
    {
        private readonly IMessageBus _messageBus;

        public ProjectCreatedEventHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(ProjectCreatedDomainEvent notification, CancellationToken ct)
        {
            await _messageBus.PublishAsync(
                new ProjectCreatedIntegrationEvent(notification.ProjectId)
            );
        }
    }
}
