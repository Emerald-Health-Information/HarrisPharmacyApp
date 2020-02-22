#region copyright

/*

Harrison1 COSC 470 2019

File = FormService.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2020-01-20			Initial
v 1.1		Dakota Logan	2020-02-13			Added methods

*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HarrisPharmacy.API.Controllers.FormFieldsAPI
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

        [HttpGet("{id}")]
        public async Task<FormField> GetFormFieldAsync(string id)
        {
            return await _formService.GetFormFieldAsync(id);
        }

        [HttpPut("update")]
        public async Task<FormField> UpdateFormFieldAsync(FormField formField)
        {
            return await _formService.UpdateFormFieldAsync(formField);
        }

        [HttpDelete("{id}")]
        public async Task<FormField> DeleteFormFieldAsync(string id)
        {
            return await _formService.DeleteFormFieldAsync(id);
        }
    }
}   