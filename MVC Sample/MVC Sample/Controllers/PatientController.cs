using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Sample.Data;
using MVC_Sample.Interfaces;
using MVC_Sample.Models;

namespace MVC_Sample.Controllers
{
	public class PatientController : Controller
	{

		private IPatientRepository _patientRepository;

		public PatientController()
		{
			_patientRepository = new PatientRepository();
		}

		public ActionResult PatientSearch()
		{
			ViewBag.ActiveMenu = "PatientSearch";
			return View();
		}
	

		[HttpPost]
		public ActionResult PatientSearch([Bind(Include = "PatientKey,PatientName,PatientLastName,FatherName,HusbandName,GuardianName,BloodGroup,ContactNumber,ContactNumber2,DOB,Age,Gender")] PatientDetails patientDetails)
		{
			PatientDetails patient = null;
			if (patientDetails.PatientKey != 0)
			{
				patient = _patientRepository.GetPatientDetailsById(patientDetails.PatientKey);
			}
			else if (string.IsNullOrWhiteSpace(patientDetails.PatientName))
			{
				patient = _patientRepository.GetPatientDetailsByName(patientDetails.PatientName, patientDetails.PatientLastName);
			}
			if (patientDetails == null)
			{
				ViewBag.NotFound = "Patient not found";
				return View();
			}
			//ViewBag.DisableValidation = "true";
			return View("Details",patient);
		}

		// GET: Patients/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Patients/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "PatientKey,PatientName,PatientLastName,FatherName,HusbandName,GuardianName,BloodGroup,ContactNumber,ContactNumber2,DOB,Age,Gender")] PatientDetails patient)
		{
			if (ModelState.IsValid)
			{
				_patientRepository.SavePatientDetails(patient);
				ViewBag.Success = "Patient details updated successfully";
				return View("Create");
			}
			return View("Create",patient);
		}

		//// POST: Patients/Edit/5
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "PatientKey,PatientName,PatientLastName,FatherName,HusbandName,GuardianName,BloodGroup,ContactNumber,ContactNumber2,DOB,Age,Gender")] Patient patient)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.Entry(patient).State = EntityState.Modified;
		//		db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View(patient);
		//}

		//// GET: Patients/Delete/5
		//public ActionResult Delete(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Patient patient = db.Patients.Find(id);
		//	if (patient == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(patient);
		//}

		//// POST: Patients/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public ActionResult DeleteConfirmed(int id)
		//{
		//	Patient patient = db.Patients.Find(id);
		//	db.Patients.Remove(patient);
		//	db.SaveChanges();
		//	return RedirectToAction("Index");
		//}

		//[HttpPost]
		//public ActionResult Find(string pid)
		//{
		//	var patientDetails = db.Patients.Find(pid);
		//	return View(patientDetails);
		//}
		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		db.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
	}
}
