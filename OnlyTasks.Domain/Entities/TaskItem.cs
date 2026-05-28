using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskStatus = OnlyTasks.Domain.Enums.TaskStatus;

namespace OnlyTasks.Domain.Entities
{
    public class TaskItem : Entity
    {
        public Guid Id { get; private set; }
        public Guid? ProjectId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TaskStatus Status { get; private set; }
        public Project? Project { get; set; }

        public TaskItem(string name, Guid? projectId, string description = "")
        {
            Id = Guid.NewGuid();
            ProjectId = projectId;
            Name = name;
            Description = description;
            Status = TaskStatus.Ongoing;

            AddDomainEvent(new TaskCreatedDomainEvent(Id));
        }

        public void NotifyDeletion() => AddDomainEvent(new TaskDeletedDomainEvent(Id));

        public void UpdateTask(Guid? projectId, string? name, string? description)
        {
            if(!projectId.HasValue)
                ProjectId = projectId;

            if(name is not null) 
                Name = name;

            if(description is not null)
                Description = description;

            AddDomainEvent(new TaskUpdatedDomainEvent(Id));
        }

        public void ChangeStatus(TaskStatus status)
        {
            if (status == this.Status)
                return;

            TaskStatus previousStatus = this.Status;

            this.Status = status;

            AddDomainEvent(new TaskStatusChangedDomainEvent(Id, previousStatus, status));
        }
    }
}
