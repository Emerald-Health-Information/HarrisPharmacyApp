using System.Collections.Generic;
using System.Threading.Tasks;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using HarrisPharmacy.Data.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<FormField>>> Get()
        {
            //List<Form> forms = await _formService.GetFormsAsync();
            //return forms;
            return await _formService.GetFormFieldsAsync();
        }

        [Route("GetOne")]
        public async Task<string> GetAllFormsAsync(string id)
        {
            //List<Form> forms = await _formService.GetFormsAsync();
            //return forms;
            FormField f = await _formService.GetFormFieldAsync(id);
            return f.FieldName + " " + f.FormFieldId;
        }
    }
}