using MVC_Sample.Data;
using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Sample.Controllers
{
    public class LoginController : Controller
    {
		private ILoginRepository _loginRepository;
		
		public LoginController()
		{
			_loginRepository = new LoginRepository();
		}
		// GET: Login
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginDetails user)
		{
			if (ModelState.IsValid)
			{
				var userSuccess = _loginRepository.Login(user);
				FormsAuthentication.SetAuthCookie(user.UserName,true);
				Session["Role"] = userSuccess.Staff.ROLE.RoleName;
				if (userSuccess == null)
				{
					ViewBag.NotValidUser = "User does not exists! Please register";
				}
				//else if (userSuccess.Staff.RoleSKey == (int)Models.Roles.Doctor)
				//{
				//	return View("Doctors", "Index");
				//}
				//else if (userSuccess.Staff.RoleSKey == (int)Models.Roles.Pharmacist)
				//{
				//	return View("Pharamacists", "Index");
				//}
				//else if (userSuccess.Staff.RoleSKey == (int)Models.Roles.Receptionist)
				//{
				//	return View("Receptionists", "Index");
				//}
				//else if (user.UserName != null && user.Password != null)
				//{
				//	ViewBag.NotValidUser = "User does not exists! Please register";
				//}
				else
				{
					return RedirectToAction("PatientSearch", "Patient");
					//return PartialView("Home");
				}
			}
			else
			{
				ViewBag.NotValidUser = "Please enter correct details";
			}
			return View();
		}
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			Session.Clear();
			Session.RemoveAll();
			return RedirectToAction("Login", "Login");
		}
	}
}