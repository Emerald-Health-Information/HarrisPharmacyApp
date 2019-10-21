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

        Task<Form> UpdateStudentAsync(Form f);

        Task<Form> DeleteStudentAsync(string id);

        Task<List<SelectListItem>> GetFormFieldsMultiSelectListAsync();
    }
}