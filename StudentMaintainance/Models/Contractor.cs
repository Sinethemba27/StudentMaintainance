using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should have letters only!")]
        [DisplayName("Name")]
        public string ContractorName { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Contractor_EmailAddress { get; set; }

        [DisplayName("Availability")]
        public string Contractor_Availability { get; set; }

        public int MaintainanceId { get; set; }
        
    }
}