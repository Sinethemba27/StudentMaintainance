using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class ContractorAddresses
    {
        [Key]
        public int ConID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int ContractorId { get; set; }
        public virtual Contractor con { get; set; }
    }
}