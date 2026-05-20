using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.DeleteTask
{
    public class TaskDeletedEventHandler : INotificationHandler<TaskDeletedDomainEvent>
    {
        private readonly IMessageBus _messageBus;

        public TaskDeletedEventHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(TaskDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageBus.PublishAsync(
                new TaskDeletedIntegrationEvent(notification.TaskId)
            );
        }
    }
}
