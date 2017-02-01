using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloridaUCTF.Models
{
	public class StampInfo
	{
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public string CreatorId { get; set; }
		
		public String Creator { get; set; }

		public DateTime ChangeDate { get; set; } = DateTime.Now;

		public string LastChangerId { get; set; }

		public String Changer { get; set; }
	}
}