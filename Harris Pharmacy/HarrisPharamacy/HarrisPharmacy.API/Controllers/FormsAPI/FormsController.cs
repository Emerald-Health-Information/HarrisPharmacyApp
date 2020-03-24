#region copyright

/*

Harrison1 COSC 470 2019

File = FormService.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Dakota Logan	2020-01-20			Initial

*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.App.Models;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HarrisPharmacy.API.Controllers.FormsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            this._formService = formService;
        }

        [HttpGet("all")]
        public async Task<List<Form>> GetFormsAsync()
        {
            return await _formService.GetFormsAsync();
        }

        [HttpGet("form/{formId}")]
        public async Task<Form> GetFormAsync(string formId)
        {
            return await _formService.GetFormAsync(formId);
        }

        [HttpPost("insert")]
        public async Task<Form> InsertFormAsync(Form form)
        {
            return await _formService.InsertFormAsync(form);
        }

        /// <summary>
        /// Updates the form in the database
        /// </summary>
        /// <param name="form">The form  to be updated</param>

        /// <returns></returns>
        [HttpPost("update")]
        public async Task<Form> UpdateFormAsync(FormUpdateDTO dto)
        {
            return await _formService.UpdateFormAsync(dto.Form, dto.FormFields);
        }

        [HttpDelete("form/{id}")]
        public async Task<Form> DeleteFormAsync(string id)
        {
            return await _formService.DeleteFormAsync(id);
        }
    }
}   