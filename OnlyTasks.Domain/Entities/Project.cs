using OnlyTasks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Domain.Entities
{
    public class Project : Entity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<TaskItem>? Tasks { get; private set; }
        public DateTime CreationDate { get; init; }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;

            AddDomainEvent(new ProjectCreatedDomainEvent(Id));
        }

        public void ChangeName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            Name = name;
            AddDomainEvent(new ProjectUpdatedDomainEvent(Id));
        }

        public void ChangeDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
                return;

            Description = description;
            AddDomainEvent(new ProjectUpdatedDomainEvent(Id));
        }

        public void NotifyDeletion() => AddDomainEvent(new ProjectDeletedDomainEvent(Id));
    }
}
