using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using BLL;
using System;
using TaskManager.Common.Logger;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        readonly private IUserBll _userBll;
        readonly private IPresentationAutoMapperConfig _automapper;
        private ILogger _logger;
        public UserController(IUserBll userBll, ITaskBll taskBll,ILogger logger, IPresentationAutoMapperConfig automapper)
        {
            _userBll = userBll;
            _automapper = automapper;
            _logger = logger;
        }
        // GET api/<controller>/5
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<User> AuthenticateUser([FromBody]User user)
        {
            try
            {
                var userData = _userBll.GetUserByEmail(user.Email, user.Password);
                if (userData == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdUser = _automapper.UserDtoToUser(userData);
                    return CreatedAtAction(nameof(AuthenticateUser), new { email = user.Email }, createdUser);
                }
            }
            catch (Exception e)
            {
                _logger.Error("Exception Thrown", e);
                throw;
            }
        }



        // POST api/<controller>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody]User user)
        {

            try
            {
                var newUser = _userBll.RegisterUser(_automapper.UserToDto(user));
                if (newUser == null)
                {
                    return BadRequest();
                }
                else
                {
                    var createdUser = _automapper.UserDtoToUser(newUser);
                    return CreatedAtAction(nameof(AuthenticateUser), new { email = user.Email }, createdUser);
                }
            }
            catch (Exception e)
            {

                _logger.Error("Exception Thrown", e);
                throw;
            }
        }


    }
}
