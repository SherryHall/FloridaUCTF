using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class Action
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Citation> Citations { get; set; }

	}
}