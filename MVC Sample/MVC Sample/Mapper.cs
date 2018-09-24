using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample
{
	public static class Mapper
	{
		public static Staff MapUserToStaff(this StaffDetails user)
		{
			Staff staff = new Staff();
			staff.Designation = user.Designation;
			staff.IsAdmin = user.IsAdmin;
			staff.RoleSKey = (int)user.Role;
			staff.StaffLastName = user.StaffLastName;
			staff.StaffName = user.StaffName;
			return staff;
		}
		public static StaffDetails MapStaffToStaffDetails(this Staff user)
		{
			StaffDetails staff = new StaffDetails();
			staff.Designation = user.Designation;
			staff.IsAdmin = user.IsAdmin;
			staff.StaffLastName = user.StaffLastName;
			staff.StaffName = user.StaffName;
			return staff;
		}
		public static Patient MapPatientDetails(this PatientDetails patientDetails)
		{
			Patient patient = new Patient
			{
				PatientKey = patientDetails.PatientKey,
				Age = patientDetails.Age,
				BloodGroup = patientDetails.BloodGroup,
				ContactNumber = patientDetails.ContactNumber,
				ContactNumber2 = patientDetails.ContactNumber2,
				DOB = patientDetails.DOB,
				FatherName = patientDetails.FatherName,
				Gender = patientDetails.Gender,
				HusbandName = patientDetails.HusbandName,
				PatientLastName = patientDetails.PatientLastName,
				PatientName = patientDetails.PatientName
			};
			return patient;
		}
		public static PatientDetails MapPatientDetails(this Patient patient)
		{
			PatientDetails patientDetails = new PatientDetails
			{
				PatientKey = patient.PatientKey,
				Age = patient.Age,
				BloodGroup = patient.BloodGroup,
				ContactNumber = patient.ContactNumber,
				ContactNumber2 = patient.ContactNumber2,
				DOB = patient.DOB,
				FatherName = patient.FatherName,
				Gender = patient.Gender,
				HusbandName = patient.HusbandName,
				PatientLastName = patient.PatientLastName,
				PatientName = patient.PatientName
			};
			return patientDetails;
		}
	}
}