using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
	public class PrescriptionDetails
	{
		public int PatientId { get; set; }

		public int DoctorId { get; set; }

		public string DoctorName { get; set; }

		public string Cause { get; set; }

		public int Amount { get; set; }
	}
}