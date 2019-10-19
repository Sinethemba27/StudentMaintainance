using System;
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
        public int Resid { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Res Reses { get; set; }

        public enum Res
        {
            StudentVillage,
            Sterling,
            WWelsingham,
            UrbanView
        }

    }
}