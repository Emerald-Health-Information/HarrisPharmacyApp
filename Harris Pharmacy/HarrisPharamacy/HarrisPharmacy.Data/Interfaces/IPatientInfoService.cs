using System;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Patients;

namespace HarrisPharmacy.Data.Interfaces
{
    /// <summary>
    /// The interface for the service class for appointments that allows the front end to interact with the database
    /// </summary>
    public interface IPatientInfoService
    {
        Task<Patient> GetPatientInformationAsync(String patientListID);
    }
}