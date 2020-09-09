using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class DoneMaintainance
    {
        [Key]
        public int MaintainanceId { get; set; }

        [DisplayName("Student Name")]
        public string StudentNAme { get; set; }

        public string StudentEmail { get; set; }

        [DisplayName("Date Reported")]
        public DateTime? ReportDate { get; set; }

        [DisplayName("Date Fixed")]
        public DateTime? FixedDate { get; set; }

        [DisplayName("Student Comment")]
        public string Comments { get; set; }

        [DisplayName("Contractor Assigned")]
        public string Contractor { get; set; }

        public string ResName { get; set; }

        public string Status { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Contractor_EmailAddress { get; set; }

        public byte[] Image { get; set; }


    }
}