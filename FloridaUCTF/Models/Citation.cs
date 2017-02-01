using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Citation : StampInfo
	{
		public int Id { get; set; }

		[StringLength(75)]
		[Display(Name = "Cit/NTA")]
		public string CitationNumber { get; set; }

		[StringLength(75)]
		[Display(Name = "Statute/Ordinance")]
		public string StatuteOrdinance { get; set; }

		[StringLength(400)]
		[Display(Name = "Work Performed")]
		public string Description { get; set; }

		public bool Withheld { get; set; }

		public bool Probation { get; set; }

		public bool PrivilegeRevoked { get; set; }

		[Display(Name = "Fine $")]
		public int FineAmount { get; set; }

		[Display(Name = "Res. $")]
		public int RestitutionAmount { get; set; }

		public int CaseId { get; set; }
		[ForeignKey("CaseId")]
		public Case Case { get; set; }

		public int? ActionId { get; set; }
		[ForeignKey("ActionId")]
		public Action Action { get; set; }

		public int? RulingId { get; set; }
		[ForeignKey("RulingId")]
		public Ruling Ruling { get; set; }

	}
}