﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Sample.Models;

namespace MVC_Sample.Controllers
{
    public class UserLoginsController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: UserLogins
        public ActionResult Index()
        {
			return View();
        }
		

		// GET: UserLogins/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // GET: UserLogins/Create
        public ActionResult Create()
        {
            ViewBag.StaffSKey = new SelectList(db.Staffs, "StaffSKey", "StaffName");
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginSKey,StaffSKey,Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.UserLogins.Add(userLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffSKey = new SelectList(db.Staffs, "StaffSKey", "StaffName", userLogin.StaffSKey);
            return View(userLogin);
        }

        // GET: UserLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffSKey = new SelectList(db.Staffs, "StaffSKey", "StaffName", userLogin.StaffSKey);
            return View(userLogin);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginSKey,StaffSKey,Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffSKey = new SelectList(db.Staffs, "StaffSKey", "StaffName", userLogin.StaffSKey);
            return View(userLogin);
        }

        // GET: UserLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserLogin userLogin = db.UserLogins.Find(id);
            db.UserLogins.Remove(userLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
