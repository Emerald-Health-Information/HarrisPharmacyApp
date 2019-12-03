#region copyright

/*

Harrison1 COSC 470 2019

File = PatientInfoService.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Entities.Patients;
using HarrisPharmacy.App.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



namespace HarrisPharmacy.App.Data.Services
{
    public class PatientInfoService : IPatientInfoService
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public PatientInfoService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Patient> GetPatientInformationAsync(String patientID)
        {
            var patient = _applicationDbContext.Patients.FirstOrDefault(p => p.PatientId == patientID);
            return patient;
        }

    }
    

    
}
