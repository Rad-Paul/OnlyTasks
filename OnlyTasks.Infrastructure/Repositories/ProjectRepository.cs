using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlyTasks.Application.Features.DTOs;
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

        public async Task CreateAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            await DispatchDomainEvents(project);
        }

        public async Task DeleteAsync(Project project, bool includeTasks)
        {
            if (includeTasks)
                _context.Tasks.RemoveRange(project.Tasks);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            project.NotifyDeletion();

            await DispatchDomainEvents(project);
        }

        public async Task<Project?> GetAsync(Guid id, bool includeTasks)
        {
            Project? project;

            if(includeTasks)
                project = await _context.Projects
                    .Include(p => p.Tasks)
                    .FirstAsync(p => p.Id == id);
            else
                project = await _context.Projects.FirstAsync(p => p.Id == id);

            return project;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            List<Project> projects = await _context.Projects.ToListAsync();

            return projects;
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
