using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Appointments;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers.AppointmentsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }


        [HttpGet("delete/{appointmentId}")]
        public async Task<Appointment> DeleteAsync(string appointmentId)
        {
            return await _appointmentService.DeleteAsync(appointmentId);
        }

        /*[HttpPut("{appointmentId}")]
        public async Task<Appointment> SetAppointmentStateFinishedAsync(string appointmentId, Appointment appointment)
        {
            return await _appointmentService.SetAppointmentStateFinishedAsync(appointment);
        }*/


        [HttpGet("list/{appointmentId}")]       
        public async Task<Appointment> GetAppointmentAsync(string appointmentId)
        {
            return await _appointmentService.GetAppointmentAsync(appointmentId);
        }

        [HttpGet("list")]
        public async Task<List<Appointment>> GetPatientListAsync()
        {
            return await _appointmentService.GetPatientListAsync();
        }

        [HttpGet("getPatientListUser/{userId}")]
        public async Task<List<Appointment>> GetPatientListUserAsync(string userId)
        {
            return await _appointmentService.GetPatientListUserAsync(userId);
        }

        [HttpGet("getOpenPatientListUser/{userId}")]
        public async Task<List<Appointment>> GetOpenPatientListUserAsync(string userId)
        {
            return await _appointmentService.GetOpenPatientListUserAsync(userId);
        }

        [HttpPost("insert")]
        public async Task<Appointment> InsertAsync(Appointment appointment)
        {
            return await _appointmentService.InsertAsync(appointment);
        }

        [HttpPut("{appointmentId}")]
        public async Task<Appointment> UpdateAppointmentAsync(string appointmentId, Appointment appointment)
        {
            return await _appointmentService.UpdateAppointmentAsync(appointment);
        }
    }
}