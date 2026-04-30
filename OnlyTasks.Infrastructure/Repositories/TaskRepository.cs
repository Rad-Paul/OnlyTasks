using System;
using OnlyTasks.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Infrastructure.Required;
using MediatR;

namespace OnlyTasks.Infrastructure.Repositories
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public TaskRepository(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            await DispatchDomainEvents(task);
        }
        
        public async Task DispatchDomainEvents(TaskItem task)
        {
            foreach(INotification domainEvent in task.DomainEvents)
            {
                await _mediator.Publish(domainEvent);
            }

            task.ClearDomainEvents();
        }
    }
}
