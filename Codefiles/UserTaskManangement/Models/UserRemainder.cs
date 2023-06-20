using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserTaskManangement.Models
{
    public class UserRemainder
    {
        public int Id { get; set; }
        public string RemainderMessage { get; set; }

        public DateTime RemainderDate { get; set; }

        public int UserId { get; set; }

        public int MessageActive { get; }
    }
}