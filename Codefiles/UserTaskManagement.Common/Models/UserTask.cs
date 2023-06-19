using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Common.Models
{
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
    }
}
