using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Entities.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HarrisPharmacy.App.Data.Interfaces
{
    public interface IFormService
    {
        Task<List<Form>> GetFormsAsync();

        Task<Form> GetFormAsync(string formId);

        Task<Form> InsertFormAsync(Form form);

        Task<Form> UpdateFormAsync(Form f);

        Task<Form> DeleteFormAsync(string id);

        List<SelectListItem> GetFormFieldsMultiSelectListAsync();

        Task<List<FormField>> GetFormFieldsAsync();

        Task<FormField> GetFormField(string formFieldId);
    }
}