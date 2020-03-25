using System;
using System.Collections.Generic;
using System.Text;

namespace HarrisPharmacy.Data.Entities.Forms
{
    /// <summary>
    /// A table that will hold the submitted forms
    /// </summary>
    public class FormSubmission : BaseEntity
    {
        public string FormSubmissionId { get; set; }

        /// <summary>
        /// Name of the form
        /// </summary>

        public string FormName { get; set; }

        /// <summary>
        /// The user who submitted this form
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The list of submissions related to this form
        /// </summary>
        public List<FormFieldSubmission> FormFieldSubmissions { get; set; } = new List<FormFieldSubmission>();
    }
}