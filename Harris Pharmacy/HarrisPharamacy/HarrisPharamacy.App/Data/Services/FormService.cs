using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Entities.Forms;
using HarrisPharmacy.App.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HarrisPharmacy.App.Data.Services
{
    public class FormService : IFormService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="applicationDbContext">the injected db context</param>
        public FormService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Get a list of all the forms in the database
        /// </summary>
        /// <returns> A list of all the forms in the database</returns>
        public async Task<List<Form>> GetFormsAsync()
        {
            return await _applicationDbContext.Forms.ToListAsync();
        }

        /// <summary>
        /// Gets the form with the corresponding form id
        /// </summary>
        /// <param name="formId"> the form id of the form you are trying to retrieve </param>
        /// <returns></returns>
        public async Task<Form> GetFormAsync(string formId)
        {
            return await _applicationDbContext.Forms.FindAsync(formId);
        }

        /// <summary>
        /// Inserts the new Form into the database
        /// </summary>
        /// <param name="form"> The form to be inserted </param>
        /// <returns> The form entity </returns>
        public async Task<Form> InsertFormAsync(Form form)
        {
            await _applicationDbContext.Forms.AddAsync(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        /// <summary>
        /// Updates the form
        /// </summary>
        /// <param name="f"> the form to be updated </param>
        /// <returns></returns>
        public async Task<Form> UpdateStudentAsync(Form f)
        {
            var form = await _applicationDbContext.Forms.FindAsync(f.FormId);

            if (form == null)
                return null;

            form.Name = f.Name;

            form.DateUpdated = DateTime.Now;
            form.Description = f.Description;

            _applicationDbContext.Forms.Update(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        public async Task<Form> DeleteStudentAsync(string id)
        {
            var student = await _applicationDbContext.Forms.FindAsync(id);

            if (student == null)
                return null;

            _applicationDbContext.Forms.Remove(student);
            await _applicationDbContext.SaveChangesAsync();

            return student;
        }

        public async Task<List<SelectListItem>> GetFormFieldsMultiSelectListAsync()
        {
            return _applicationDbContext.FormFields.Select(a =>
               new SelectListItem
               {
                   Value = a.FormFieldId.ToString(),
                   Text = a.FieldName
               }).ToList();
        }

        private bool FormExists(string id)
        {
            return _applicationDbContext.Forms.Any(e => e.FormId == id);
        }
    }
}