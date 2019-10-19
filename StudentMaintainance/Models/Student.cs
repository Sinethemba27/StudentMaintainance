using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentMaintainance.Models
{
    public class Student
    {
        [Key]     
        public int studentNo { get; set; }
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [DisplayName("Room Number")]
        public int RoomNo { get; set; }
        [DisplayName("Residence")]
        [ForeignKey("Resid")]
        public Residence Residence { get; set; }
        public int Resid { get; set; }
    }
}