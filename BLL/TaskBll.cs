using System.Collections.Generic;
using TaskManager.Common.DTO;
using DAL.Repository;
using TaskManager.Common.Logger;
using System;

namespace BLL
{
    public class TaskBll : ITaskBll
    {
        public ITaskDal _taskDal;
        public ILogger _logger; 
        public TaskBll(ITaskDal taskDal, ILogger logger)
        {
            _taskDal = taskDal;
            _logger = logger;
        }
        public TaskDto AddNewTask(TaskDto taskDto)
        {
            try
            {
                return _taskDal.AddNewTask(taskDto);
            }
            catch (Exception e)
            {
                _logger.Error("Exception Thrown", e);
                throw;
            }
        }

        public bool DeleteTask(int id)
        {
            try
            {
                return _taskDal.DeleteTask(id);
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }



        public IEnumerable<TaskDto> GetUserTask(string Email)
        {
            try
            {
                return _taskDal.GetUserTask(Email);
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }

        public bool EditTask(TaskDto task)
        {
            return _taskDal.EditTask(task);
        }
       
    }
}
