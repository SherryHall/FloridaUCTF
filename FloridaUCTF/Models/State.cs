using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class State
	{
		[Key]
		[StringLength(2)]
		public string StateCode { get; set; }
		public string StateName { get; set; }
	}
}