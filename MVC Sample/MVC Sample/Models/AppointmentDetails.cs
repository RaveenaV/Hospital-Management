using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Models
{
	public class AppointmentDetails : Appointment
	{
		//public IEnumerable<StaffDetails> Doctors { get; set; }
		public List<SelectListItem> Doctors { get; set; }

		public List<SelectListItem> Patients { get; set; }
	}
}