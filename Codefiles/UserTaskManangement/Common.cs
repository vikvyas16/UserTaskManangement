using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserTaskManangement
{
    public class Common
    {
        public static string BaseAPIUrl;

        static Common() {
            BaseAPIUrl = "http://localhost:63349/api/";
        }
    }
}