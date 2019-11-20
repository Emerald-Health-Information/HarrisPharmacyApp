using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Entities.Patients;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HarrisPharmacy.App.Data.Interfaces
{
    /// <summary>
    /// The interface for the service class for appointments that allows the front end to interact with the database
    /// </summary>
    public interface IPatientInfoService
    {
        Task<Patient> GetPatientInformationAsync(String patientListID);
    }
}