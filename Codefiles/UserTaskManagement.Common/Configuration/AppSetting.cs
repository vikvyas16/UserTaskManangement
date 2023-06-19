using UserTaskManagement.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UserTaskManagement.Common.Configuration
{
    public class AppSetting : IAppSetting
    {
        public AppSetting()
        {
            DbConnection = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            AddUser = "usp_InsertUser";
            GetUser = "GetUserByEmail";
            GetUsers = "GetUsers";
            AddUserTask = "usp_InsertUserTask";
            GetUserTask = "GetUserTaskByUserId";
        }

        public string DbConnection { get; }
      
        public string AddUser { get; }
        public string GetUser { get; }

        public string GetUsers { get; }

        public string AddUserTask { get; }

        public string GetUserTask { get; }
    }
}