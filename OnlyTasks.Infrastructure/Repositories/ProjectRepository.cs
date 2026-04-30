using MediatR;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using OnlyTasks.Infrastructure.Required;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public ProjectRepository(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            await DispatchDomainEvents(project);
        }

        public async Task DispatchDomainEvents(Project project)
        {
            foreach(INotification eventItem in project.DomainEvents)
            {
                await _mediator.Publish(eventItem);
            }

            project.ClearDomainEvents();
        }
    }
}
