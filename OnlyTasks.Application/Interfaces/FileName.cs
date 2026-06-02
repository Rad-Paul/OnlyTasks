using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Interfaces
{
    public interface IRabbitMQPublisher
    {
        public Task PublishTask(TaskCreatedIntegrationEvent notification);
    }
}
