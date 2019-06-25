using System.Collections.Generic;
using TaskManager.Common.DTO;
using TaskManager.Models;

namespace TaskManager
{
    public interface IPresentationAutoMapperConfig
    {
        Task TaskDtoToTask(TaskDto taskDto);
        TaskDto TaskToTaskDto(Task task);
        User UserDtoToUser(UserDto userDto);
        UserDto UserToDto(User user);
        IEnumerable<Task> DtoListToTask(IEnumerable<TaskDto> task);
    }
}