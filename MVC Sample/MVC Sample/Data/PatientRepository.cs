using MVC_Sample.Interfaces;
using MVC_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Data
{
	public class PatientRepository : IPatientRepository
	{
		HospitalManagementEntities hospitalEntities = new HospitalManagementEntities();
		public PatientDetails GetPatientDetailsById(int id)
		{
			var patient = hospitalEntities.Patients.Where(p => p.PatientKey == id).FirstOrDefault();
		
			return patient.MapPatientDetails();
		}

		public PatientDetails GetPatientDetailsByName(string firstName, string lastName)
		{
			var patientDetails = hospitalEntities.Patients.Where(p => p.PatientName == firstName && p.PatientLastName == lastName).FirstOrDefault();
			return patientDetails.MapPatientDetails();
		}

		public int SavePatientDetails(PatientDetails patientDetails)
		{
			Patient patient = patientDetails.MapPatientDetails();
			try
			{
				var existingPatient = hospitalEntities.Patients.FirstOrDefault(s => s.PatientKey == patient.PatientKey);
				if (existingPatient != null)
				{
					existingPatient = patient;
				}
				else
				{
					hospitalEntities.Patients.Add(patient);
				}
				hospitalEntities.SaveChanges();
				return patient.PatientKey;
			}
			catch(Exception ex)
			{
				return 0;
			}
		}

	}
}