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
    /// <summary>
    /// The service class for appointments that allows the front end to connect to the database
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
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
        public async Task<PatientList> DeleteAsync(string id)
        {
            var appointment = await _applicationDbContext.PatientLists.FindAsync(id);

            if (appointment == null)
                return null;

            _applicationDbContext.PatientLists.Remove(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }
        /// <summary>
        /// Gets the appointment with the corresponding appointment id 
        /// </summary>
        /// <param name="patientListId"></param>
        /// <returns></returns>
        public async Task<PatientList> GetAppointmentAsync(string patientListId)
        {
            var appointment = await _applicationDbContext.PatientLists
                .SingleOrDefaultAsync(a => a.PatientListId == patientListId);
            return appointment;
        }
        /// <summary>
        /// Gets a list of all the appointments in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<PatientList>> GetPatientListAsync()
        {
            return await _applicationDbContext.PatientLists
                .ToListAsync();
        }
        /// <summary>
        /// Gets a list of all the appointments in the database that are assigned to a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<PatientList>> GetPatientListUserAsync(string userId)
        {
            List<PatientList> patientList = await _applicationDbContext.PatientLists.ToListAsync();
            return patientList.FindAll(pl => userId.Contains(pl.UserId));
        }
        /// <summary>
        /// Inserts a new appointment into the database
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<PatientList> InsertAsync(PatientList appointment)
        {
            await _applicationDbContext.PatientLists.AddAsync(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }
        /// <summary>
        /// Updates an appointment in the database
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public async Task<PatientList> UpdateAppointmentAsync(PatientList a)
        {
            var appointment = await _applicationDbContext.PatientLists.FindAsync(a.PatientListId);
            if (appointment == null)
                return null;

            appointment.PatientId = a.PatientId;

            appointment.DateUpdated = DateTime.Now;
            appointment.Description = a.Description;

            _applicationDbContext.PatientLists.Update(appointment);
            await _applicationDbContext.SaveChangesAsync();

            return appointment;
        }
    }
}
