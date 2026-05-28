using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;
using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;

namespace OnlyTasks.Application.Features.Tasks.Commands.ChangeTaskStatus
{
    public class TaskStatusChangedHandler : INotificationHandler<TaskStatusChangedDomainEvent>
    {
        private readonly IMessageBus _messageBus;

        public TaskStatusChangedHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(TaskStatusChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageBus.PublishAsync(
                new TaskStatusChangedIntegrationEvent(notification.TaskId, notification.Previous, notification.NewStatus)
            );
        }
    }
}
