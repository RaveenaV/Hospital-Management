using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Sample.Data
{
	public class StaffRepository : IStaffRepository
	{
		private HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();

		public void AddUpdateStaff(StaffDetails user)
		{
			try
			{
				Staff staff = user.MapUserToStaff();
				var existingStaff = hospitalEntities.Staffs.FirstOrDefault(s => s.StaffKey == user.StaffKey);
				if (existingStaff != null)
				{
					existingStaff = staff;
				}
				else
				{
					hospitalEntities.Staffs.Add(staff);
				}
				hospitalEntities.SaveChanges();
			}
			catch(Exception ex)
			{

			}
		}
	}
}