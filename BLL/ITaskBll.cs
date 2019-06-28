using System.Collections.Generic;
using TaskManager.Common.DTO;

namespace BLL
{
    public interface ITaskBll
    {
        TaskDto AddNewTask(TaskDto taskDto);
        bool DeleteTask(int id);
        IEnumerable<TaskDto> GetUserTask(string Email);
        bool EditTask(TaskDto taskDto);
        // IEnumerable<TaskDto> GetAllTask();
    }
}