#region copyright

/*

Harrison1 COSC 470 2019

File = FormService.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.Data;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HarrisPharmacy.Data.Services
{
    /// <summary>
    /// The service class for forms that allows the front end to interact with the database
    /// </summary>
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
            return await _applicationDbContext.Forms
                .Include(f => f.FormWithFields)
                .ToListAsync();
        }

        /// <summary>
        /// Get a list of all the FormsFields in the database
        /// </summary>
        /// <returns> A list of all the FormFields in the database</returns>
        public async Task<List<FormField>> GetFormFieldsAsync()
        {
            return await _applicationDbContext.FormFields
                .ToListAsync();
        }

        /// <summary>
        /// Gets the form with the corresponding form id
        /// </summary>
        /// <param name="formId"> the form id of the form you are trying to retrieve </param>
        /// <returns></returns>
        public async Task<Form> GetFormAsync(string formId)
        {
            var form = await _applicationDbContext.Forms
                 .Include(f => f.FormWithFields)
                     .ThenInclude(f => f.FormField)
                 .SingleOrDefaultAsync(f => f.FormId == formId);

            return form;
        }

        /// <summary>
        /// Gets the formField with the corresponding formFieldId
        /// </summary>
        /// <param name="formFieldId"> the formFieldId of the formField you are trying to retrieve </param>
        /// <returns></returns>
        public async Task<FormField> GetFormFieldAsync(string formFieldId)
        {
            var formField = await _applicationDbContext.FormFields
                .Include(f => f.FormWithFields)
                .SingleOrDefaultAsync(f => f.FormFieldId == formFieldId);

            return formField;
        }

        /// <summary>
        /// Inserts the new form field to the database
        /// </summary>
        /// <param name="formField">The form field to be inserted</param>
        /// <returns></returns>
        public async Task<FormField> InsertFormFieldAsync(FormField formField)
        {
            formField.FormFieldId = Guid.NewGuid().ToString();
            formField.DateCreated = DateTime.Now;
            formField.DateUpdated = DateTime.Now;
            var result = await _applicationDbContext.FormFields.AddAsync(formField);
            await _applicationDbContext.SaveChangesAsync();

            return formField;
        }

        /// <summary>
        /// Inserts the new Form into the database
        /// </summary>
        /// <param name="form"> The form to be inserted </param>
        /// <returns> The form entity </returns>
        public async Task<Form> InsertFormAsync(Form form)
        {
            var result = await _applicationDbContext.Forms.AddAsync(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        /// <summary>
        /// Updates the form, use this if your updating the fields and not just the name/description
        /// </summary>
        /// <param name="f"> the form to be updated </param>
        /// <param name="selectedFormFields" > </param>
        /// <returns></returns>
        public async Task<Form> UpdateFormAsync(Form f, List<FormField> selectedFormFields)
        {
            var form = await _applicationDbContext.Forms.FindAsync(f.FormId);
            if (form == null)
                return null;

            _applicationDbContext.FormWithFields.RemoveRange(form.FormWithFields);

            List<FormWithFields> formWithFields = CreateFormWithFields(f.Description, selectedFormFields, form);

            form.FormWithFields = formWithFields;
            form.DateUpdated = DateTime.Now;
            _applicationDbContext.Forms.Update(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        // <summary>
        /// Updates the form, use this if your just updating the name/description
        /// </summary>
        /// <param name="f"> the form to be updated </param>
        /// <returns></returns>
        public async Task<Form> UpdateFormAsync(Form f)
        {
            var form = await _applicationDbContext.Forms.FindAsync(f.FormId);
            if (form == null)
                return null;
            _applicationDbContext.Forms.Update(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        /// <summary>
        /// Deletes a form with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Form> DeleteFormAsync(string id)
        {
            var form = await _applicationDbContext.Forms.FindAsync(id);

            if (form == null)
                return null;

            _applicationDbContext.Forms.Remove(form);
            await _applicationDbContext.SaveChangesAsync();

            return form;
        }

        /// <summary>
        /// Deletes a form field with the supplied id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FormField> DeleteFormFieldAsync(string id)
        {
            // TODO: Delete the form if it's the only field?
            var formField = await _applicationDbContext.FormFields
                .Include(f => f.FormWithFields)
                .FirstOrDefaultAsync(f => f.FormFieldId == id);

            if (formField == null)
                return null;

            // Delete any FormWithFields entries related to this field, not sure why this isn't automatic like it is when we delete a form
            foreach (var formWithFields in formField.FormWithFields)
            {
                _applicationDbContext.FormWithFields.Remove(formWithFields);
            }

            _applicationDbContext.FormFields.Remove(formField);

            await _applicationDbContext.SaveChangesAsync();

            return formField;
        }

        public async void UpdateFormFieldAsync(FormField formField)
        {
            formField.DateUpdated = DateTime.Now;

            _applicationDbContext.FormFields.Update(formField);
            await _applicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns all of the form fields as a list of select list items
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetFormFieldsMultiSelectListAsync()
        {
            return _applicationDbContext.FormFields.Select(a =>
             new SelectListItem
             {
                 Value = a.FormFieldId.ToString(),
                 Text = a.FieldName
             }).ToList();
        }

        /// <summary>
        /// Creates a form with the selected formFields
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="selectedFormFields"></param>
        /// <returns></returns>
        public async Task<Form> CreateFormAsync(string name, string description, List<FormField> selectedFormFields)
        {
            // Create a new form
            var form = new Form()
            {
                FormId = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
            };

            List<FormWithFields> formWithFields = CreateFormWithFields(description, selectedFormFields, form);

            // TODO: Save all to db
            _applicationDbContext.FormWithFields.AddRange(formWithFields);

            return await InsertFormAsync(form);
        }

        private static List<FormWithFields> CreateFormWithFields(string description, List<FormField> selectedFormFields, Form form)
        {
            // The list of all the formsWithFields
            List<FormWithFields> formsWithFields = new List<FormWithFields>();
            // Create all the new FormWithFields
            foreach (var formField in selectedFormFields)
            {
                var formWithFields = new FormWithFields()
                {
                    FormWithFieldsId = Guid.NewGuid().ToString(),
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Description = description,
                    Form = form,
                    FormField = formField,
                    FormId = form.FormId,
                    FormFieldId = formField.FormFieldId
                };
                formsWithFields.Add(formWithFields);
            }

            return formsWithFields;
        }

        /// <summary>
        /// See if the form exists given the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FormExists(string id)
        {
            return _applicationDbContext.Forms.Any(e => e.FormId == id);
        }
    }
}