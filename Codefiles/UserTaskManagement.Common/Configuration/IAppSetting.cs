using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Common.Configuration
{
    public interface  IAppSetting
    {
        string DbConnection { get; }
       
        string AddUser { get; }
        string GetUser { get; }

        string GetUsers { get; }

        string AddUserTask { get; }
        string GetUserTask { get; }

        string AddUserRemider { get; }

        string getUserRemider { get; }
    }
}
