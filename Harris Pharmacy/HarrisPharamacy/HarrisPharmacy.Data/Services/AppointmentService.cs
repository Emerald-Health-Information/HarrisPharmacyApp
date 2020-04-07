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
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Entities.Appointments;
using HarrisPharmacy.Data.Entities.Patients;
using HarrisPharmacy.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarrisPharmacy.Data.Services
{
    /// <summary>
    /// The service class for appointments that allows the front end to connect to the database
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        /// <summary>
        /// Get a patient given a patient id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>

        public async Task<Patient> GetPatientAsync(string patientId)
        {
            return await _applicationDbContext.Patients
                .SingleOrDefaultAsync(f => f.PatientId == patientId);
        }

        /// <summary>
        /// Get a list of all the patients in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _applicationDbContext.Patients
                .ToListAsync();
        }

        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="applicationDbContext">the injected db context</param>
        public AppointmentService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Deletes appointment with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Appointment> DeleteAsync(string id)
        {
            var appointment = await _applicationDbContext.Appointments.FindAsync(id);

            if (appointment == null)
                return null;

            _applicationDbContext.Appointments.Remove(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }

        /// <summary>
        /// Set The state of the appointment to ""
        /// </summary>
        /*public async Task<Appointment> SetAppointmentStateFinishedAsync(Appointment appointment)
        {
            _applicationDbContext.Appointments.Update(appointment);
            await _applicationDbContext.SaveChangesAsync();
            return appointment;
        }*/

        /// <summary>
        /// Gets the appointment with the corresponding appointment id
        /// </summary>
        /// <param name="patientListId"></param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentAsync(string appointmentId)
        {
            var appointment = await _applicationDbContext.Appointments
                .SingleOrDefaultAsync(a => a.AppointmentId == appointmentId);
            return appointment;
        }

        /// <summary>
        /// Gets a list of all the appointments in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Appointment>> GetPatientListAsync()
        {
            return await _applicationDbContext.Appointments
                .ToListAsync();
        }

        /// <summary>
        /// Gets a list of all the appointments in the database that are assigned to a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Appointment>> GetPatientListUserAsync(string userId)
        {
            List<Appointment> patientList = await _applicationDbContext.Appointments.ToListAsync();
            return patientList.FindAll(pl => userId.Contains(pl.UserId));
        }

        /// <summary>
        /// Gets a list of all of the open appointments in the DB that are assigned to a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Appointment>> GetOpenPatientListUserAsync(string userId)
        {
            List<Appointment> openPatientList = await _applicationDbContext.Appointments
                .Where(pl => pl.AppointmentState == "open").ToListAsync();
            return openPatientList.FindAll(pl => userId.Contains(pl.UserId));
        }

        /// <summary>
        /// Inserts a new appointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> InsertAsync(Appointment appointment)
        {
            await _applicationDbContext.Appointments.AddAsync(appointment);
            appointment.AppointmentState = "open";
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }

        /// <summary>
        /// Updates an appointment in the database
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            //var appointment = await _applicationDbContext.Appointments.FindAsync(a.AppointmentId);
            //if (appointment == null)
            //return null;

            //appointment.PatientId = a.PatientId;

            //appointment.DateUpdated = DateTime.Now;
            //appointment.Description = a.Description;
            
            _applicationDbContext.Appointments.Update(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }
    }
}