using OnlyTasks.Domain.Interfaces;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Infrastructure.Required;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

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

        public async Task<IEnumerable<TaskItem>> GetTasksAsync(Guid? projectId, TaskStatus? status)
        {
            IQueryable<TaskItem> query = _context.Tasks.AsQueryable();

            bool getUnassignedTasks = projectId is null;

            if (!getUnassignedTasks)
                query = query.Where(t => t.ProjectId == projectId);
            else
                query = query.Where(t => !t.ProjectId.HasValue);

            if (status is not null)
                query = query.Where(t => t.Status == status);


            List<TaskItem> tasks = await query.ToListAsync();

            return tasks;
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
