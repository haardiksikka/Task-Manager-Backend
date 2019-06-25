using System.Collections.Generic;
using TaskManager.Common.DTO;
using DAL.Models;
using System.Linq;

namespace DAL.Repository
{
    public class TaskDal : ITaskDal
    {
        public IDatabaseAutomapperConfig _mapper;
        public TaskManagerContext _context;
        public TaskDal(IDatabaseAutomapperConfig mapper,TaskManagerContext context )
        {
            _mapper = mapper;
            _context = context;
        }
        public TaskDto AddNewTask(TaskDto task)
        {
            _context.Tasks.Add(_mapper.TaskDtoToTask(task));
            _context.SaveChanges();

            return task;
        }

        public IEnumerable<TaskDto> GetUserTask(string Email)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email.Equals(Email));
            var task = _context.Tasks.Where(x => x.UserId == user.UserId).ToList();

            return _mapper.TaskListToDto(task);
        }

        public bool DeleteTask(int id)
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
    }
}
