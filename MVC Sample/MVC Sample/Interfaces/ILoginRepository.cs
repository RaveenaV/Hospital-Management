﻿using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Sample.Interfaces
{
	public interface ILoginRepository
	{
		UserLogin Login(LoginDetails user);
	}
}
