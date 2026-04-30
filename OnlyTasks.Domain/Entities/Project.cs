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
        public string Name { get; set; }
        public string Description { get;  set; }
        public IEnumerable<TaskItem> Tasks { get; set; } = [];
        public DateTime CreationDate { get; init; }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
        }
    }
}
