using System.Collections.Generic;
using TaskManager.Common.DTO;

namespace BLL
{
    public interface ITaskBll
    {
        TaskDto AddNewTask(TaskDto taskDto);
        bool DeleteTask(int id);
        IEnumerable<TaskDto> GetUserTask(string Email);
        // IEnumerable<TaskDto> GetAllTask();
    }
}