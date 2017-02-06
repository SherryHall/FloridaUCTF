using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Ruling
	{
		[Display(Name = "Ruling")]
		public int Id { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Citation> Citations { get; set; }
	}
}