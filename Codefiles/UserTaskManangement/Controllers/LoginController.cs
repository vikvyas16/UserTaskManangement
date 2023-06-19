using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UserTaskManangement.Models;

namespace UserTaskManangement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private string BaseUrl = Common.BaseAPIUrl;
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public JsonResult UserValidate(User usr)
        {
            var user = new User() { Email = usr.Email, Password = usr.Password };
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri(BaseUrl +"Login");
                var postTask = client.PostAsJsonAsync<User>("Login", user);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();
                    var userResult = readTask.Result;

                    if(userResult.UserId!=0)
                    {
                        Session["UserName"] = userResult.FirstName + " "+ userResult.LastName;
                        Session["UserId"] = userResult.UserId;
                    }
                    user.UserId = userResult.UserId;
                }
            }
            return Json(user);

        }
    }
}