using OnlyTasks.Domain.Entities;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

namespace OnlyTasks.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task CreateTaskAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetTasksAsync(Guid? projectId, TaskStatus? status);
        Task<TaskItem?> GetTaskAsync(Guid id);
        Task DeleteTaskAsync(TaskItem task);
    }
}
