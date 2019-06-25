using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using BLL;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        readonly private IUserBll _userBll;
        readonly private IPresentationAutoMapperConfig _automapper;
        public UserController(IUserBll userBll, ITaskBll taskBll, IPresentationAutoMapperConfig automapper)
        {
            _userBll = userBll;
            _automapper = automapper;
        }     
        // GET api/<controller>/5
        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<User> AuthenticateUser([FromBody]User user)
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



        // POST api/<controller>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody]User user)
        {
           
            var newUser = _userBll.RegisterUser(_automapper.UserToDto(user));
            if(newUser == null)
            {
                return BadRequest();
            }
            else
            {
                var createdUser = _automapper.UserDtoToUser(newUser);
                return CreatedAtAction(nameof(AuthenticateUser), new { email = user.Email }, createdUser);
            }
        }

       
    }
}
