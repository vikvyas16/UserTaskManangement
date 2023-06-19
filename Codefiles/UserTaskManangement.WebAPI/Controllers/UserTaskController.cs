using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services.Repositories;

namespace UserTaskManangement.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:63281", headers: "*", methods: "*")]
    public class UserTaskController : ApiController
    {
        IUserTaskService _userTaskService;

        public UserTaskController(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        [HttpPost]
        [Route("api/AddUserTask")]
        public async Task AddUserTask([FromBody] UserTask user)
        {
            await _userTaskService.AddUserTask(user);


        }

        [HttpGet]
        [Route("api/GetUserTask")]
        public async Task<List<UserTask>> GetUserTask(string userId)
        {
             var UserTaskData = await _userTaskService.GetUserTaskByUserID(userId);

            return UserTaskData;
        }
    }
}
