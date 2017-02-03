using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
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

		[Required]
		[StringLength(75)]
		[Display(Name = "County")]
		public string CaseCounty { get; set; }

	}

	public class AddOffenderViewModel
	{
		public Offender Offender { get; set; }

		public OffenderAddress OffenderAddress { get; set; }
	}

}