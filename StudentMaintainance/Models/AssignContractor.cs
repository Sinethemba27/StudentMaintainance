﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class AssignContractor
    {
        [Key]
        public int acontract { get; set; }

        [DisplayName("Contractor")]
        [ForeignKey("ContractorId")]
        public Contractor Contractor { get; set; }
        public int ContractorId { get; set; }

        [DisplayName("Maintainance")]
        [ForeignKey("MaintainanceId")]
        public Maintainance Maintainance { get; set; }
        public int MaintainanceId { get; set; }

        public string Status { get; set; }
        public string Comment { get; set; }


        public string Res { get; set; }

        public byte[] Image { get; set; }

    }
}