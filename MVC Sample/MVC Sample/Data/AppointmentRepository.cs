using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Data
{
	public class AppointmentRepository :IAppointmentRepository
	{
		private HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();

		public void GetPatientPreviousVisits(int patientId)
		{
			hospitalEntities.PatientVisits.Where(x => x.PatientId == patientId).OrderByDescending(x=>x.DateOfVisit).Take(10).ToList();
		}
		public void SaveAppointmentDetails(AppointmentDetails appointmentDetails)
		{
			hospitalEntities.Appointments.Add(new Appointment {
				DoctorId = appointmentDetails.DoctorId,
				PatientId = appointmentDetails.PatientId,
				Problem = appointmentDetails.Problem,
				CreatedDate = DateTime.Now
			});
			hospitalEntities.SaveChanges();
		}
		public List<Appointment> GetDoctorAppointments(int doctorId)
		{
			return hospitalEntities.Appointments.Where(s => s.DoctorId == doctorId).ToList();
		}
		public void DeleteAppointment(Appointment appointment)
		{
			hospitalEntities.Appointments.Remove(appointment);
			hospitalEntities.SaveChanges();
		}
	}
}