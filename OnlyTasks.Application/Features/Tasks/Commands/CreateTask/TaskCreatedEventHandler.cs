using MediatR;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Commands.CreateTask
{
    public class TaskCreatedEventHandler : INotificationHandler<TaskCreatedDomainEvent>
    {
        private readonly IMessageBus _messageBus;

        public TaskCreatedEventHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(TaskCreatedDomainEvent notification, CancellationToken ct)
        {
            await _messageBus.PublishAsync(
                new TaskCreatedIntegrationEvent(notification.TaskId)
            );
        }
    }
}
