using MVC_Sample.Data;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Sample.Interfaces
{
	public interface IAppointmentRepository 
	{
		//void SaveAppointmentDetails(Appointment appointment);
		void GetPatientPreviousVisits(int patientId);
		void SaveAppointmentDetails(AppointmentDetails appointmentDetails);
		List<Appointment> GetDoctorAppointments(int doctorId);
		void DeleteAppointment(Appointment appointment);
		//List<SelectListItem> GetAllDoctors();
	}
}
