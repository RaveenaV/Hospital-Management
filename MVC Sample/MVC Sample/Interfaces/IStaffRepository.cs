using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Sample.Interfaces
{
	public interface IStaffRepository
	{
		//IEnumerable<StaffDetails> GetAllDoctors();
		//List<SelectListItem> GetAllDoctors();
		void AddUpdateStaff(StaffDetails user);
	}
}
