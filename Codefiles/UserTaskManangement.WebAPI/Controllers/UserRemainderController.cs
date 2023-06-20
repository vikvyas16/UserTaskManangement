using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services.Repositories;

namespace UserTaskManangement.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:63281", headers: "*", methods: "*")]
    public class UserRemainderController : ApiController
    {

        IUserRemainderServices _userRemainderService;

        public UserRemainderController(IUserRemainderServices userRemainderServices)
        {
            _userRemainderService = userRemainderServices;
        }

        [HttpPost]
        [Route("api/AddUserRemainder")]
        public async Task PostUserRemainder([FromBody] UserRemainder user)
        {
            await _userRemainderService.AddUserRemider(user);


        }

        [HttpGet]
        [Route("api/GetUserRemainder")]
        public async Task<IEnumerable<UserRemainder>> GetUserRemainder(string userId)
        {
            var UserTaskData = await _userRemainderService.GetUserRemiderAsync(userId);

            return UserTaskData;
        }
    }
}
