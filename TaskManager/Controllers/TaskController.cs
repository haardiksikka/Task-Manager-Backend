using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace TaskManager.Controllers
{
    
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        public ITaskBll _taskBll;
        public IUserBll _userBll;
        public IPresentationAutoMapperConfig _mapper;

        public TaskController(ITaskBll taskBll, IPresentationAutoMapperConfig mapper, IUserBll userBll)
        {
            _taskBll = taskBll;
            _mapper = mapper;
            _userBll = userBll;
        }
        [HttpPost]
        [Route("newtask")]
        public async Task<ActionResult<TaskManager.Models.Task>> AddNewTask([FromBody]TaskManager.Models.Task task)
        {
            var user = _userBll.GetUser(task.Email);
            task.UserId = user.UserId;
            var newTask = _taskBll.AddNewTask(_mapper.TaskToTaskDto(task));
            var result = _mapper.TaskDtoToTask(newTask);
            return CreatedAtAction(nameof(AddNewTask), new { email = user.Email }, result);
        }
        [HttpGet("{email}")]
        [Route("usertask")]
        public IEnumerable<TaskManager.Models.Task> GetUserTasks(string email)
        {
            return _mapper.DtoListToTask(_taskBll.GetUserTask(email));
        }

        [HttpDelete("{id}")]
        [Route("deletetask")]
        public bool DeleteTask(int id)
        {
           return _taskBll.DeleteTask(id);
        }
    }
}
