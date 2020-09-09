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
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID { get; set; }

        public int studentNo { get; set; }

        [DisplayName("Student Name")]
        public string Name { get; set; }

        [DisplayName("Room Number")]
        public int RoomNo { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DisplayName("Residence")]
        public int Resid { get; set; }

        public string ResName { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();

        public string getResName()
        {
            var name = (from R in db.Residences
                        where Resid == R.ResId
                        select R.ResName).FirstOrDefault();
            return name;
        }
    }
}