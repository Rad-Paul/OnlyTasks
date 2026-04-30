using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlyTasks.Application.Interfaces;
using OnlyTasks.Domain.Interfaces;
using OnlyTasks.Infrastructure.Repositories;
using OnlyTasks.Infrastructure.Required;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("server=DESKTOP-H628PQM\\SQLEXPRESS; database=OnlyTasks; Integrated Security=true; TrustServerCertificate=true"));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddSingleton<IMessageBus, InMemoryMessageBus>();

            return services;
        }
    }
}
