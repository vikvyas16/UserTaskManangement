using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Web.Http.Cors;
//using System.Web.Mvc;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Services.Repositories;
using System.Web.Http;
//using System.Web.Mvc;

namespace UserTaskManangement.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:63281", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: User
        IUserService _userService;
        //public ActionResult Index()
        //{
        //    return View();
        //}
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
    }
}