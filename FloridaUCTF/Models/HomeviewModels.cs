using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class AddOffenderViewModel
	{
		public Offender Offender { get; set; }

		public OffenderAddress OffenderAddress { get; set; }
	}

	public class SaveVerdictViewModel
	{
		public int CiteId { get; set; }

		public int Action { get; set; }

		public int Ruling { get; set; } 

		public bool Withheld { get; set; }

		public bool Probation { get; set; }

		public bool Revoked { get; set; }

		public int Fine { get; set; }

		public int Restitution { get; set; }

	}

	public class SearchViewModel
	{
		[StringLength(75)]
		[Display(Name = "Last")]
		public string LastName { get; set; }

		[Display(Name = "First")]
		[StringLength(75)]
		public string FirstName { get; set; }

		[Display(Name = "AKA's")]
		public string AKA { get; set; }

		[StringLength(30)]
		[Display(Name = "Drive Lic#")]
		public string DriveLicense { get; set; }

		[StringLength(100)]
		[Display(Name = "Bus. Name")]
		public string BusinessName { get; set; }

		[StringLength(75)]
		[Display(Name = "Case #")]
		public string CaseNumber { get; set; }

		[StringLength(75)]
		[Display(Name = "City")]
		public string CaseCity { get; set; }

		[StringLength(75)]
		[Display(Name = "County")]
		public string CaseCounty { get; set; }

	}

	public class SearchResultsViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Last")]
		public string LastName { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "First")]
		public string FirstName { get; set; }

		[StringLength(30)]
		[Display(Name = "Driver's License")]
		public string DriveLicense { get; set; }


		[StringLength(255)]
		[Display(Name = "Last")]
		public string LastAKA { get; set; }

		[StringLength(255)]
		[Display(Name = "First")]
		public string FirstAKA { get; set; }

		IList<Case> Cases { get; set; }

		[NotMapped]
		[Display(Name = "Offender Name")]
		public string Full_Name
		{
			get { return this.LastName + ", " + this.FirstName; }
		}
		[NotMapped]
		[Display(Name = "AKAs")]
		public string AllAKAs
		{
			get { return this.LastAKA + " " + this.FirstAKA; }
		}
	}


}