/*

   Harrison1 COSC 471 2019

   File = FormSubmissions.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
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
        /// <summary>
        /// The Id for the form submission
        /// </summary>
        public string FormSubmissionId { get; set; }

        /// <summary>
        /// The Id of the patent this form was filled out for
        /// </summary>
        public string PatientId { get; set; }

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