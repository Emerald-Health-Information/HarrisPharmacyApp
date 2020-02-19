using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers.FormsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFieldController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormFieldController(IFormService formService)
        {
            this._formService = formService;
        }

        [HttpPost("insert")]
        public async Task<FormField> InsertFormFieldAsync(FormField formField)
        {
            return await _formService.InsertFormFieldAsync(formField);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<FormField>>> GetFormFieldsAsync()
        {
            return await _formService.GetFormFieldsAsync();
        }

        [HttpGet("list/{id}")]
        public async Task<FormField> GetFormFieldAsync(string id)
        {
            return await _formService.GetFormFieldAsync(id);
        }

        [HttpPost("update")]
        public async Task<int> UpdateFormFieldAsync(FormField formField)
        {
            return await _formService.UpdateFormFieldAsync(formField);
        }

        [HttpGet("delete/{id}")]
        public async Task<FormField> DeleteFormFieldAsync(string id)
        {
            return await _formService.DeleteFormFieldAsync(id);
        }
    }
}   