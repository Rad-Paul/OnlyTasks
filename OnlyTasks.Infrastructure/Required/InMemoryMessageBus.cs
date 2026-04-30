using OnlyTasks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Infrastructure.Required
{
    internal class InMemoryMessageBus : IMessageBus
    {
        //rabbitmq to be added
        public Task PublishAsync<T>(T message)
        {
            Console.WriteLine($"Event published: {typeof(T).Name}");
            return Task.CompletedTask;
        }
    }
}
