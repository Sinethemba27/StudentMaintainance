﻿    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class Residence
    {
        [Key]
        public int ResId { get; set; }
        public string ResName { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FullAddress { get; set; }
    }
}