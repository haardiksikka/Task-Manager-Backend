using System.Collections.Generic;
using DAL.Models;
using TaskManager.Common.DTO;

namespace DAL
{
    public interface IDatabaseAutomapperConfig
    {
        Task TaskDtoToTask(TaskDto taskDto);
        TaskDto TaskToTaskDto(Task task);
        User UserDtoToUser(UserDto userDto);
        UserDto UserToDto(User user);
        IEnumerable<TaskDto> TaskListToDto(IEnumerable<Task> task);
    }
}