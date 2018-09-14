using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
	public class PatientDetails
	{
		public int PatientKey { get; set; }

		[Required(ErrorMessage = "UserName is required")]
		public string PatientName { get; set; }

		[Required(ErrorMessage = "LastName is required")]
		public string PatientLastName { get; set; }

		public string FatherName { get; set; }
		public string HusbandName { get; set; }
		public string GuardianName { get; set; }

		[Required(ErrorMessage = "BloodGroup is required")]
		public string BloodGroup { get; set; }

		[Required(ErrorMessage = "ContactNumber is required")]
		[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter valid number")]
		[StringLength(10, ErrorMessage = "The Mobile number must contains 10 characters", MinimumLength = 10)]
		public string ContactNumber { get; set; }

		public string ContactNumber2 { get; set; }

		public Nullable<System.DateTime> DOB { get; set; }

		[Required(ErrorMessage = "Age is required")]
		[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter valid number")]
		public Nullable<int> Age { get; set; }

		[Required(ErrorMessage = "Gender is required")]
		public string Gender { get; set; }
	}
}