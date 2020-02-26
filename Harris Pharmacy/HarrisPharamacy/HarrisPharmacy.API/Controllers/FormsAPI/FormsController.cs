#region copyright

/*
Harrison1 COSC 470 2019
File = FormService.cs
Author = Daniel Claggett
Date = 2020-02-23
License = MIT
				Modification History
Version		Author			Date				Desc
v 1.0		Daniel Claggett	2020-02-23			Initial
*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HarrisPharmacy.API.Controllers.FormsAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            this._formService = formService;
        }

        [HttpGet("list")]
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

        [HttpPut("update")]
        public async Task<Form> UpdateFormAsync(Form f)
        {
            return await _formService.UpdateFormAsync(f);
        }

        [HttpDelete("form/{id}")]
        public async Task<Form> DeleteFormAsync(string id)
        {
            return await _formService.DeleteFormAsync(id);
        }
    }
}