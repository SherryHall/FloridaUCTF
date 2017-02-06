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

		[Display(Name = "Revoke Privlgs")]
		public bool PrivilegeRevoked { get; set; }

		[Display(Name = "Fine $")]
		[Range(0,99999)]
		public int FineAmount { get; set; }

		[Display(Name = "Res. $")]
		[Range(0, 99999)]
		public int RestitutionAmount { get; set; }

		public int CaseId { get; set; }
		[ForeignKey("CaseId")]
		public Case Case { get; set; }

		[Display(Name = "Action")]
		public int ActionId { get; set; } = 1;
		[ForeignKey("ActionId")]
		public Action Action { get; set; }

		[Display(Name = "Ruling")]
		public int RulingId { get; set; } = 1;
		[ForeignKey("RulingId")]
		public Ruling Ruling { get; set; }

	}
}