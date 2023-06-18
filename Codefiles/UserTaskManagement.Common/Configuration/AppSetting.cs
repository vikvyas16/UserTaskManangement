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
        }

        //public string UpdateProduct { get; }
        public string DbConnection { get; }
        //public string GetProductLookUp { get; }
        //public string GetProductById { get; }
        //public string GetProductCategory { get; }
        //public string GetProductAttributeLookUpByCategoryId { get; }
        //public string AddProductAttributes { get; }
        public string AddUser { get; }
        


    }
}