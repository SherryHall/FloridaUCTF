using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Ruling
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public ICollection<Citation> Citations { get; set; }
	}
}