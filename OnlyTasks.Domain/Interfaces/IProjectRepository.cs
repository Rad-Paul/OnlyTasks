using OnlyTasks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task CreateProjectAsync(Project project);
    }
}
