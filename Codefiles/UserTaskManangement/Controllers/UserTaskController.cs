using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UserTaskManangement.Models;

namespace UserTaskManangement.Controllers
{
    public class UserTaskController : Controller
    {
        // GET: UserTask
        private string BaseUrl = Common.BaseAPIUrl;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdUserTask()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserTask()
        {
            List<UserTask> userlst = new List<UserTask>();

            using (var client = new HttpClient())
            {
                var userId = Session["UserId"]??"0";
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("GetUserTask?userId=2");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<UserTask>>();
                    readTask.Wait();
                    userlst = readTask.Result;

                }
            }
            return Json(new { data = userlst }, JsonRequestBehavior.AllowGet);

        }
    }
}