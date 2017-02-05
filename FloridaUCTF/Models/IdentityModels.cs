using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FloridaUCTF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
		[Required]
		[StringLength(75)]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "Job Title")]
		public string Title { get; set; }

		[Required]
		[StringLength(100)]
		public string Jurisdiction { get; set; }

		[Required]
		[StringLength(15,MinimumLength = 10)]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Work Phone")]
		public string WorkPhone { get; set; }

		[Display(Name = "Ext")]
		public string WorkExtension { get; set; }

		[Required]
		[StringLength(100)]
		public string Address { get; set; }

		[Required]
		[StringLength(75)]
		public string City { get; set; }

		[Required]
		[StringLength(2)]
		public string State { get; set; }

		[Required]
		[StringLength(10)]
		public string Zip { get; set; }

		public ICollection<Case> Cases { get; set; }

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

		public virtual DbSet<Offender> Offenders { get; set; }
		public virtual DbSet<OffenderAddress> OffenderAddresses { get; set; }
		public virtual DbSet<Case> Cases { get; set; }
		public virtual DbSet<Citation> Citations { get; set; }
		public virtual DbSet<Action> Actions { get; set; }
		public virtual DbSet<Ruling> Rulings { get; set; }
		public virtual DbSet<State> States { get; set; }


	}
}