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

        [HttpGet("appointment/{appointmentId}")]       
        public async Task<Appointment> GetAppointmentAsync(string appointmentId)
        {
            return await _appointmentService.GetAppointmentAsync(appointmentId);
        }

        [HttpGet("list")]
        public async Task<List<Appointment>> GetPatientListAsync()
        {
            return await _appointmentService.GetPatientListAsync();
   
        }
    }
}