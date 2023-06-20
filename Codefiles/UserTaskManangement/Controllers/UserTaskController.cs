using Newtonsoft.Json;
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

            List<UserNotification> userNotification = new List<UserNotification>();
            string[] pendingStatus = new string[]{ "InProgress", "Pending" };

            List<UserTask> userlst = new List<UserTask>();

            using (var client = new HttpClient())
            {
                var userId = Session["UserId"] ?? "2";
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("GetUserTask?userId=" + userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<UserTask>>();
                    readTask.Wait();
                    userlst = readTask.Result;

                }
            }

            var durDateTasks = userlst?.Where(x => x?.DueDate <= DateTime.Now && pendingStatus.Contains(x?.TaskStatus)).ToList();
            var Pcount=userlst?.Where(x => x.TaskStatus == "Pending")?.Count();
            var Dcount = userlst?.Where(x => x.TaskStatus == "Done")?.Count();

            foreach (var duetask in durDateTasks)
            {
                UserNotification userNotificationData = new UserNotification();
                userNotificationData.TaskTitle = duetask.TaskTitle;
                userNotificationData.NotificationMessage = string.Concat("Task Id:"+ duetask.TaskId + "=> "+duetask?.TaskTitle +" is over due. Need to check it");
                userNotification.Add(userNotificationData);
            }

            ViewBag.notifications = JsonConvert.SerializeObject(userNotification);
            ViewBag.userRemainder = SetUserRemainder();
            ViewBag.TotalPending = Pcount;
            ViewBag.TotalDone = Dcount;
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
                var userId = Session["UserId"]??"2";
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("GetUserTask?userId="+ userId);
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

        private string SetUserRemainder()
        {
            List<UserNotification> userNotification = new List<UserNotification>();
            List<UserRemainder> userRemainderList = new List<UserRemainder>();
            using (var client = new HttpClient())
            {
                var userId = Session["UserId"] ?? "2";
                client.BaseAddress = new Uri(BaseUrl);
                var responseTask = client.GetAsync("GetUserRemainder?userId=" + userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<UserRemainder>>();
                    readTask.Wait();
                    userRemainderList = readTask.Result;

                }
            }

            var userRemainders = userRemainderList?.Where(x => x?.RemainderDate.Date == DateTime.Now.Date && x.MessageActive==0).ToList();

            foreach (var userRemainder in userRemainders)
            {
                UserNotification userNotificationData = new UserNotification();
                userNotificationData.TaskTitle = "User Remainder";
                userNotificationData.NotificationMessage = userRemainder.RemainderMessage;
                userNotification.Add(userNotificationData);
            }
            return JsonConvert.SerializeObject(userNotification);
        }
    }
}