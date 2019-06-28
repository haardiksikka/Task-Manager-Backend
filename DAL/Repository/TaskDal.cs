using System.Collections.Generic;
using TaskManager.Common.DTO;
using DAL.Models;
using System.Linq;
using System;
using TaskManager.Common.Logger;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TaskDal : ITaskDal
    {
        public IDatabaseAutomapperConfig _mapper;
        public TaskManagerContext _context;
        public ILogger _logger;
        public TaskDal(IDatabaseAutomapperConfig mapper, TaskManagerContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public TaskDto AddNewTask(TaskDto task)
        {
            try
            {
                _context.Tasks.Add(_mapper.TaskDtoToTask(task));
                _context.SaveChanges();
                return task;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TaskDto> GetUserTask(string Email)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email.Equals(Email));
                var task = _context.Tasks.Where(x => x.UserId == user.UserId).ToList();
                return _mapper.TaskListToDto(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTask(int id)
        {
            try
            {
                var task = _context.Tasks.Find(id);
                if (task == null)
                {
                    return false;
                }
                else
                {
                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception )
            {
                throw;
            }
        }

        public bool EditTask(TaskDto taskDto)
        {
            var task = _mapper.TaskDtoToTask(taskDto);
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
            return true;

        }
    }
}
