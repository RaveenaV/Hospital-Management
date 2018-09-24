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
	public class StaffController : Controller
	{
		private IStaffRepository iStaffRepository;
		public StaffController()
		{
			iStaffRepository = new StaffRepository();
		}
		// GET: Staffs
		//public ActionResult Index()
		//{
		//    return View(db.Staffs.ToList());
		//}

		[HttpGet]
		public ActionResult Prescription()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Prescription(PrescriptionDetails patientPrescription)
		{
			return View("Prescription");
		}
		//public ActionResult GetAllDoctors ()
		//{
		//	iStaffRepository.GetAllDoctors();	
		//	return View();
		//}

		// GET: Staffs/Details/5
		//public ActionResult Details(int? id)
		//      {
		//          if (id == null)
		//          {
		//              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//          }
		//          Staff staff = db.Staffs.Find(id);
		//          if (staff == null)
		//          {
		//              return HttpNotFound();
		//          }
		//          return View(staff);
		//      }

		// GET: Staffs/Create
		public ActionResult Create()
		{
			ViewBag.ActiveMenu = "addStaff";
			return View();
		}

		// POST: Staffs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "StaffKey,StaffName,StaffLastName,Designation,Role,IsAdmin")] StaffDetails user)
		{
			if (ModelState.IsValid)
			{
				iStaffRepository.AddUpdateStaff(user);
				ViewBag.Success = "User updated successfully";
			}
			//ModelState.Clear();
			return View(user);
		}

		// GET: Staffs/Edit/5
		//public ActionResult Edit(int? id)
		//{
		//    if (id == null)
		//    {
		//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//    }
		//    Staff staff = db.Staffs.Find(id);
		//    if (staff == null)
		//    {
		//        return HttpNotFound();
		//    }
		//    return View(staff);
		//}

		// POST: Staffs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "StaffKey,StaffName,StaffLastName,Designation,RoleSKey,IsAdmin")] Staff staff)
		//{
		//    if (ModelState.IsValid)
		//    {
		//        db.Entry(staff).State = EntityState.Modified;
		//        db.SaveChanges();
		//        return RedirectToAction("Index","UserLogins");
		//    }
		//    return View(staff);
		//}

		//// GET: Staffs/Delete/5
		//public ActionResult Delete(int? id)
		//{
		//    if (id == null)
		//    {
		//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//    }
		//    Staff staff = db.Staffs.Find(id);
		//    if (staff == null)
		//    {
		//        return HttpNotFound();
		//    }
		//    return View(staff);
		//}

		//// POST: Staffs/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public ActionResult DeleteConfirmed(int id)
		//{
		//    Staff staff = db.Staffs.Find(id);
		//    db.Staffs.Remove(staff);
		//    db.SaveChanges();
		//    return RedirectToAction("Index");
		//}

		//protected override void Dispose(bool disposing)
		//{
		//    if (disposing)
		//    {
		//        db.Dispose();
		//    }
		//    base.Dispose(disposing);
		//}
	}
}
