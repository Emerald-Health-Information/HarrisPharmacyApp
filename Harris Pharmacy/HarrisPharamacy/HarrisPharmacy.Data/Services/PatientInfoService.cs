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
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Patients;
using HarrisPharmacy.Data.Interfaces;

namespace HarrisPharmacy.Data.Services
{
    public class PatientInfoService : IPatientInfoService
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        public PatientInfoService(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public async Task<Patient> GetPatientInformationAsync(String patientId)
        {
            var patient = ApplicationDbContext.Patients.FirstOrDefault(p => p.PatientId == patientId);
            return patient;
        }
    }
}