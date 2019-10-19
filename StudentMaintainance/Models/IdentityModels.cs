using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentMaintainance.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Student Number")]
        public int studentNo { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Room Number")]
        public int RoomNo { get; set; }
        [DisplayName("Residence")]
        [ForeignKey("Resid")]
        public Residence Residence { get; set; }
        public int Resid { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<StudentMaintainance.Models.Residence> Residences { get; set; }

        public System.Data.Entity.DbSet<StudentMaintainance.Models.Contractor> Contractors { get; set; }

        public System.Data.Entity.DbSet<StudentMaintainance.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<StudentMaintainance.Models.Maintainance> Maintainances { get; set; }

        public System.Data.Entity.DbSet<StudentMaintainance.Models.AssignContractor> AssignContractors { get; set; }
    }
}