using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Data
{
	public class LoginRepository : ILoginRepository
	{
		private HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();
		public UserLogin Login(LoginDetails user)
		{
			return hospitalEntities.UserLogins.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
		}
	}
}