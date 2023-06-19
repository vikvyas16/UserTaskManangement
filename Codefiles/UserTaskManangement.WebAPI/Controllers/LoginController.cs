using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services.Repositories;


namespace UserTaskManangement.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:63281", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
         IUserService _userService;
      
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/Login")]
        public async Task<User> PostValidateUser([FromBody] User user)
        {
            return await _userService.GetUserByEmailAsync(user.Email.Trim());


        }
    }
}
