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
		public string Street { get; set; }

		[Required]
		[StringLength(75)]
		public string City { get; set; }

		[Required]
		[StringLength(2)]
		public string State { get; set; }

		[Required]
		[StringLength(10)]
		public string Zip { get; set; }

		public int? OffenderId { get; set; }
		[ForeignKey("OffenderId")]
		public Offender Offender { get; set; }
	}
}