using System.Collections.Generic;
using TaskManager.Common.DTO;
using DAL.Repository;

namespace BLL
{
    public class TaskBll : ITaskBll
    {
        public ITaskDal _taskDal;
        public TaskBll(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public TaskDto AddNewTask(TaskDto taskDto)
        {
           return _taskDal.AddNewTask(taskDto);
        }

        public bool DeleteTask(int id)
        {
            return _taskDal.DeleteTask(id);
        }



        public IEnumerable<TaskDto> GetUserTask(string Email)
        {
            return _taskDal.GetUserTask(Email);
        }
       
    }
}
