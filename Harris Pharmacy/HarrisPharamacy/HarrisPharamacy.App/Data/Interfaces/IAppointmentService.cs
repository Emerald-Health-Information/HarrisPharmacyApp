#region copyright

/*

Harrison1 COSC 470 2019

File =

Author =

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
using HarrisPharmacy.App.Data.Entities.Appointments;
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
        /// Get a patient from the database with a patient id
        /// </summary>
        /// <returns></returns>
        Task<Patient> GetPatientAsync(string patientId);

        /// <summary>
        /// Gets the list of all patients in the database
        /// </summary>
        /// <returns></returns>
        Task<List<Patient>> GetPatientsAsync();

        /// <summary>
        /// Gets a list of all the appointments in the database
        /// </summary>
        /// <returns></returns>
        Task<List<Appointment>> GetPatientListAsync();

        /// <summary>
        /// Gets the Appointment with the corresponding patient id
        /// </summary>
        /// <param name="patientId"> the patient id of the appointment you are trying to retrieve </param>
        /// <returns></returns>
        Task<Appointment> GetAppointmentAsync(string patientId);

        /// <summary>
        /// Inserts the new Appointment into the database
        /// </summary>
        /// <param name="appointment"> The form to be inserted </param>
        /// <returns> The form entity </returns>
        Task<Appointment> InsertAsync(Appointment appointment);

        /// <summary>
        /// Updates the appointment
        /// </summary>
        /// <param name="a"> the form to be updated </param>
        /// <returns></returns>
        Task<Appointment> UpdateAppointmentAsync(Appointment a);

        /// <summary>
        /// Deletes a appointment with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Appointment> DeleteAsync(string id);

        /// <summary>
        /// Gets a list of all the appointments in the databse that ar assigned to a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Appointment>> GetPatientListUserAsync(string userId);
    }
}