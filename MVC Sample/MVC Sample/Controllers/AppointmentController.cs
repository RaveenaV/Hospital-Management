using MVC_Sample.Data;
using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Controllers
{
	public class AppointmentController : Controller
	{
		private IAppointmentRepository appointmentRepository;
		private IStaffRepository staffRepository;
		public AppointmentController()
		{
			appointmentRepository = new AppointmentRepository();
			staffRepository = new StaffRepository();
		}

		[HttpGet]
		public ActionResult BookAppointment()
		{
			ViewBag.ActiveMenu = "Appointment";
			AppointmentDetails appointment = new AppointmentDetails();
			appointment.Doctors = Common.GetAllDoctors();
			appointment.Patients = Common.GetAllPatients();
			return PartialView("BookAppointment", appointment);
		}

		[HttpPost]
		public ActionResult BookAppointment(AppointmentDetails appointmentDetails)
		{
			if (ModelState.IsValid)
			{
				appointmentRepository.SaveAppointmentDetails(appointmentDetails);
				ViewBag.Status = "Appointment booked successfully";
				appointmentDetails.Doctors = Common.GetAllDoctors();
				appointmentDetails.Patients = Common.GetAllPatients();
				return PartialView("BookAppointment", appointmentDetails);
			}
			ViewBag.Status = "Some error occured! Please try again!! ";
			return PartialView("BookAppointment", appointmentDetails);
		}

		[HttpGet]
		public ActionResult GetDoctorAppointments()
		{
			List<Appointment> appointments = appointmentRepository.GetDoctorAppointments((int)Session["StaffId"]);
			return PartialView("Appointments", appointments);
		}

		public ActionResult DeleteAppointment(Appointment appointment)
		{
			appointmentRepository.DeleteAppointment(appointment);
			return PartialView("Appointments");
		}

		[HttpGet]
		public ActionResult PatientPreviousVisits(int patientId)
		{
			appointmentRepository.GetPatientPreviousVisits(patientId);
			return View();
		}
	}
}