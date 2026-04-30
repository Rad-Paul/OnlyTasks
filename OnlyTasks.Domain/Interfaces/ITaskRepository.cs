using OnlyTasks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlyTasks.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task CreateTaskAsync(TaskItem task);
    }
}
