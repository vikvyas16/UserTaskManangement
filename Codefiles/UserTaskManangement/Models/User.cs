using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserTaskManangement.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int UserId { get; set; }

    }

    public class UserTask
    {
        public string TaskTitle { get; set; }

        public string TaskId { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DueDate { get; set; }

        public string Comment { get; set; }

        public string AssigneeId { get; set; }

        public string CreatedBy { get; set; }

        public string FullName { get; set; }
        public string TaskStatus { get; set; }

        public string TaskPriority { get; set; }
    }
}