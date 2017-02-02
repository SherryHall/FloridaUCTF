using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Offender : StampInfo
	{
		public int Id { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "Last")]
		public string LastName { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "First")]
		public string FirstName { get; set; }

		[StringLength(75)]
		[Display(Name = "Middle")]
		public string MiddleName { get; set; }

		[StringLength(30)]
		[Display(Name = "Driver's License")]
		public string DriveLicense { get; set; }

		[StringLength(2)]
		[Display(Name = "Issuing State")]
		public string DriveLicenseState { get; set; }

		[StringLength(255)]
		[Display(Name = "Last")]
		public string LastAKA { get; set; }

		[StringLength(255)]
		[Display(Name = "First")]
		public string FirstAKA { get; set; }

		[NotMapped]
		[Display(Name = "Offender Name")]
		public string Full_Name
		{
			get { return this.LastName + ", " + this.FirstName + " " + this.MiddleName; }
		}
		[NotMapped]
		[Display(Name = "AKAs")]
		public string AllAKAs
		{
			get { return this.LastAKA + " " + this.FirstAKA; }
		}

		public int?  DefaultAddressId { get; set; }

		public ICollection<OffenderAddress> OffenderAddresses { get; set; }

		public ICollection<Case> Cases { get; set; }



	}
}