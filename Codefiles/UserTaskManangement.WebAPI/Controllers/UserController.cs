using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services.Repositories;

namespace UserTaskManangement.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:63281", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: User
        IUserService _userService;
      
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/User")]
        public async Task PostProduct([FromBody] User user)
        {
            await _userService.AddUser(user);
          

        }
        [HttpGet]
        [Route("api/Users")]
        public async Task<IEnumerable<User>> getUsers()
        {
            return await _userService.GetUsers();


        }
    }
}