using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
	public class StaffDetails
	{
		public int StaffKey { get; set; }

		[Required(ErrorMessage = "UserName is required")]
		public string StaffName { get; set; }
		public string StaffLastName { get; set; }
		public string Designation { get; set; }
		[Required(ErrorMessage = "Role is required")]
		public Roles Role { get; set; }
		[Required(ErrorMessage = "IsAdmin is required")]
		public Nullable<bool> IsAdmin { get; set; }

		public List<StaffDetails> staffDetails { get; set; }
	}
}