using MediatR;
using OnlyTasks.Application.Features.DTOs;
using OnlyTasks.Domain.Entities;
using OnlyTasks.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlyTasks.Application.Features.Tasks.Queries.GetTask
{
    public class GetTaskHandler : IRequestHandler<GetTaskQuery, TaskItemDto>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskItemDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            TaskItem? task = await _taskRepository.GetTaskAsync(request.TaskId);

            if (task is null)
                throw new Exception("Task not found.");

            TaskItemDto taskDto = TaskItemDto.EntityToDto(task);

            return taskDto;
        }
    }
}
