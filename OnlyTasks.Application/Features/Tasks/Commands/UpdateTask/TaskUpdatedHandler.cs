using MediatR;
using OnlyTasks.Application.Features.Tasks.Commands.DeleteTask;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.UpdateTask
{
    public class TaskUpdatedHandler :INotificationHandler<TaskUpdatedDomainEvent>
    {
        private readonly IMessageBus _messageBus;

        public TaskUpdatedHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(TaskUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageBus.PublishAsync(
                new TaskUpdatedIntegrationEvent(notification.TaskId)
            );
        }
    }
}
