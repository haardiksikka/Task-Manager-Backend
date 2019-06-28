using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using System;
using TaskManager.Common.Logger;

namespace TaskManager.Controllers
{
    
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        public ITaskBll _taskBll;
        public IUserBll _userBll;
        public ILogger _logger;
        public IPresentationAutoMapperConfig _mapper;

        public TaskController(ITaskBll taskBll,ILogger logger, IPresentationAutoMapperConfig mapper, IUserBll userBll)
        {
            _taskBll = taskBll;
            _mapper = mapper;
            _userBll = userBll;
            _logger = logger;
        }
        [HttpPost]
        [Route("newtask")]
        public async Task<ActionResult<TaskManager.Models.Task>> AddNewTask([FromBody]TaskManager.Models.Task task)
        {
            try
            {
                var user = _userBll.GetUser(task.Email);
                task.UserId = user.UserId;
                var newTask = _taskBll.AddNewTask(_mapper.TaskToTaskDto(task));
                var result = _mapper.TaskDtoToTask(newTask);
                return CreatedAtAction(nameof(AddNewTask), new { email = user.Email }, result);
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }
        [HttpGet("{email}")]
        [Route("usertask")]
        public IEnumerable<TaskManager.Models.Task> GetUserTasks(string email)
        {
            try
            {
                return _mapper.DtoListToTask(_taskBll.GetUserTask(email));
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        [Route("deletetask")]
        public bool DeleteTask(int id)
        {
            try
            {
                return _taskBll.DeleteTask(id);
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }

        [HttpPost]
        [Route("edittask")]
        public bool EditTask([FromBody] TaskManager.Models.Task task)
        {
            var user = _userBll.GetUser(task.Email);
            task.UserId = user.UserId;
            return _taskBll.EditTask(_mapper.TaskToTaskDto(task));
        }
    }
}
