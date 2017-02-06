using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class OffenderAddress
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name ="Home Address")]
		public string Address { get; set; }

		[Required]
		[StringLength(75)]
		public string City { get; set; }

		[Required]
		[StringLength(2)]
		public string State { get; set; } = "FL";

		[Required]
		[StringLength(10)]
		public string Zip { get; set; }

		[NotMapped]
		[Display(Name = "City,State,Zip")]
		public string CityStateZip
		{
			get { return this.City + ", " + this.State + " " + Zip; }
		}

		public int? OffenderId { get; set; }
		[ForeignKey("OffenderId")]
		public Offender Offender { get; set; }

	}
}