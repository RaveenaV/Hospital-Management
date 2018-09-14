using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Controllers
{
	public class DoctorsController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}