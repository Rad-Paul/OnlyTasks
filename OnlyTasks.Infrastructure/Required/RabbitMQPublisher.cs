using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlyTasks.Infrastructure.Required
{
    public class RabbitMQPublisher : IRabbitMQPublisher
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "taskCreatedQueue";

        public async Task PublishTask(TaskCreatedIntegrationEvent notification)
        {
            ConnectionFactory factory = new ();
            using IConnection connection = await factory.CreateConnectionAsync();
            using IChannel channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: _queueName,
                durable: true,
                exclusive: true,
                autoDelete: false,
                arguments: null
            );

            var json = JsonSerializer.Serialize(notification);
            var body = Encoding.UTF8.GetBytes(json);

            await channel.BasicPublishAsync(exchange: "",
                routingKey: _queueName,
                body: body
            );

            Console.WriteLine($"Published task with id {notification.TaskId}");
        }
    }
}
