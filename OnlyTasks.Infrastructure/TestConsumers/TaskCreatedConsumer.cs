using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlyTasks.Application.Features.Tasks.Commands.CreateTask;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlyTasks.Infrastructure.TestConsumers
{
    public class TaskCreatedConsumer : BackgroundService
    {
        private readonly IMediator _mediator;
        private IConnection? _connection;
        private IChannel? _channel;

        public TaskCreatedConsumer(IServiceProvider serviceProvider, IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            ConnectionFactory factory = new()
            {
                HostName = "localhost"
            };

            _connection = await factory.CreateConnectionAsync(cancellationToken);
            _channel = await _connection.CreateChannelAsync(cancellationToken: cancellationToken);

            await _channel.QueueDeclareAsync(
                queue: "taskCreatedQueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: cancellationToken
            );

            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            AsyncEventingBasicConsumer consumer = new (_channel!);

            consumer.ReceivedAsync += async (_, delivery) =>
            {
                try
                {
                    var json = Encoding.UTF8.GetString(delivery.Body.ToArray());
                    var taskCreated = JsonSerializer.Deserialize<TaskCreatedIntegrationEvent>(json);

                    if (taskCreated is null)
                    {
                        await _channel!.BasicNackAsync(
                            delivery.DeliveryTag,
                            false,
                            false
                        );

                        return;
                    }

                    await _mediator.Publish(taskCreated, cancellationToken);

                    await _channel!.BasicAckAsync(
                        delivery.DeliveryTag,
                        false
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    await _channel!.BasicNackAsync(
                        delivery.DeliveryTag,
                        false,
                        true
                    );
                }
            };

            await _channel!.BasicConsumeAsync(
                queue: "taskCreatedQueue",
                autoAck: false,
                consumer: consumer,
                cancellationToken: cancellationToken
            );

            await Task.Delay(Timeout.Infinite, cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel != null)
                await _channel.CloseAsync(cancellationToken);

            if (_connection != null)
                await _connection.CloseAsync(cancellationToken);

            await base.StopAsync(cancellationToken);
        }
    }
}
