using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Sample.Interfaces
{
	interface IPatientRepository
	{
		PatientDetails GetPatientDetailsById(int id);
		PatientDetails GetPatientDetailsByName(string firstName, string lastName);
		int SavePatientDetails(PatientDetails patient);
	}
}
