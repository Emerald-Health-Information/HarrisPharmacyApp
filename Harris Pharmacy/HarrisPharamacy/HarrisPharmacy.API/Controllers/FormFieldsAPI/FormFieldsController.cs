#region copyright

/*

Harrison1 COSC 471 2019

File = FormFieldsController.cs

Author = Taylor Adam

Date = 2020-01-20

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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        /// <summary>
        /// Inserts the new form field to the database
        /// </summary>
        /// <param name="formField">The form field to be inserted</param>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<FormField> InsertFormFieldAsync(FormField formField)
        {
            return await _formService.InsertFormFieldAsync(formField);
        }

        /// <summary>
        /// Get a list of all the FormsFields in the database
        /// </summary>
        /// <returns> A list of all the FormFields in the database</returns>
        [HttpGet("all")]
        public async Task<List<FormField>> GetFormFieldsAsync()
        {
            return await _formService.GetFormFieldsAsync();
        }

        /// <summary>
        /// Returns all of the form fields as a list of select list items
        /// </summary>
        /// <returns></returns>
        [HttpGet("selectlist")]
        public List<SelectListItem> GetFormFieldsMultiSelectListAsync()
        {
            return _formService.GetFormFieldsMultiSelectListAsync();
        }

        /// <summary>
        /// Gets the formField with the corresponding formFieldId
        /// </summary>
        /// <param name="formFieldId"> the formFieldId of the formField you are trying to retrieve </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<FormField> GetFormFieldAsync(string id)
        {
            return await _formService.GetFormFieldAsync(id);
        }

        /// <summary>
        /// Updates the form field in the database
        /// </summary>
        /// <param name="formField">The form field to be updated</param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<FormField> UpdateFormFieldAsync(FormField formField)
        {
            return await _formService.UpdateFormFieldAsync(formField);
        }

        /// <summary>
        /// Deletes a form field with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<FormField> DeleteFormFieldAsync(string id)
        {
            return await _formService.DeleteFormFieldAsync(id);
        }
    }
}