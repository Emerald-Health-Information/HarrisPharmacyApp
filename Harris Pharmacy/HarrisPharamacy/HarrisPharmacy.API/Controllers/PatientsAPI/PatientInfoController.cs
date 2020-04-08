using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Patients;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers.FormsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : ControllerBase
    {
        private readonly IPatientInfoService _patientInfoService;

        public PatientInfoController(IPatientInfoService PatientInfoService)
        {
            this._patientInfoService = PatientInfoService;
        }

        [HttpGet("patient/{patientId}")]
        public async Task<Patient> GetPatientInformationAsync(String patientId)
        {
            return await _patientInfoService.GetPatientInformationAsync(patientId);
        }
    }
}