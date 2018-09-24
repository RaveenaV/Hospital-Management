using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Data
{
	public class Common
	{
		public static List<SelectListItem> GetAllDoctors()
		{
			HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();
			List<SelectListItem> items = new List<SelectListItem>();
			//List<StaffDetails> staffs = new List<StaffDetails>();
			var staffDetails = hospitalEntities.Staffs.Where(s => s.RoleSKey == (int)Roles.Doctor).ToList();
			foreach (var staff in staffDetails)
			{
				//staffs.Add(staff.MapStaffToStaffDetails());
				items.Add(new SelectListItem
				{
					Text = staff.StaffName + staff.StaffLastName,
					Value = staff.StaffKey.ToString()
				});
			}
			return items;
		}

		public static List<SelectListItem> GetAllPatients()
		{
			HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();
			List<SelectListItem> items = new List<SelectListItem>();
			var patientDetails = hospitalEntities.Patients.ToList();
			foreach (var patient in patientDetails)
			{
				//staffs.Add(staff.MapStaffToStaffDetails());
				items.Add(new SelectListItem
				{
					Text = patient.PatientName + patient.PatientLastName,
					Value = patient.PatientKey.ToString()
				});
			}
			return items;
		}
	}
}