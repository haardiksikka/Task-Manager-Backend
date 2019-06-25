using System.Collections.Generic;
using TaskManager.Common.DTO;

namespace DAL.Repository
{
    public interface ITaskDal
    {
        TaskDto AddNewTask(TaskDto task);
        IEnumerable<TaskDto> GetUserTask(string email);
        bool DeleteTask(int id);
    }
}