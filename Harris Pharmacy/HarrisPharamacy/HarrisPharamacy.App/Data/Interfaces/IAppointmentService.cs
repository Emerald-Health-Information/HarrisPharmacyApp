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
    public interface IAppointmentService
    {
        /// <summary>
        /// Gets the list of all the Appointments in the database
        /// </summary>
        /// <returns></returns>
        Task<List<PatientList>> GetPatientListAsync();

        /// <summary>
        /// Gets the Appointment with the corresponding patient id
        /// </summary>
        /// <param name="patientId"> the patient id of the appointment you are trying to retrieve </param>
        /// <returns></returns>
        Task<PatientList> GetAppointmentAsync(string patientId);

        /// <summary>
        /// Inserts the new Appointment into the database
        /// </summary>
        /// <param name="appointment"> The form to be inserted </param>
        /// <returns> The form entity </returns>
        Task<PatientList> InsertAsync(PatientList appointment);

        /// <summary>
        /// Updates the appointment
        /// </summary>
        /// <param name="a"> the form to be updated </param>
        /// <returns></returns>
        Task<PatientList> UpdateAppointmentAsync(PatientList a);

        /// <summary>
        /// Deletes a appointment with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PatientList> DeleteAsync(string id);
    }
}
