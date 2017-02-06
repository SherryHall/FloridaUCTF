using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Case : StampInfo
	{
		public int Id { get; set; }

		[Required]
		public int OffenderId { get; set; }

		[StringLength(75)]
		[Display(Name = "Case #")]
		public string CaseNumber { get; set; }

		[Display(Name = "Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
		public DateTime CaseDate { get; set; } = DateTime.Now;

		[StringLength(75)]
		[Display(Name = "City")]
		public string CaseCity { get; set; }

		[Required]
		[StringLength(75)]
		[Display(Name = "County")]
		public string CaseCounty { get; set; }

		[StringLength(100)]
		[Display(Name = "Business Name")]
		public string BusinessName { get; set; }

		public int OffenderAddressId { get; set; }

		[ForeignKey("OffenderAddressId")]
		[Display(Name = "Home Address")]
		public virtual OffenderAddress OffenderAddress { get; set; }

		[ForeignKey("OffenderId")]
		public virtual Offender Offender { get; set; }

		public string OfficialContactId { get; set; }
		[ForeignKey("OfficialContactId")]
		public virtual ApplicationUser OfficialContact { get; set; }

		public virtual IList<Citation> Citations { get; set; }
	}
}