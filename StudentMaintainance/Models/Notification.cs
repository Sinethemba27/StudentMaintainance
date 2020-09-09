using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentMaintainance.Models
{
    public class Notification
    {
        [Key]
        public long NotificationID { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool IsRead { get; set; }
    }
}