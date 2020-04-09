/*

   Harrison1 COSC 471 2019

   File = FormFieldSubmissions.cs

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
using HarrisPharmacy.Data.Enums;

namespace HarrisPharmacy.Data.Entities.Forms
{
    /// <summary>
    /// Holds the subbmited form fields and their respective values
    /// </summary>
    public class FormFieldSubmission
    {
        public string FormFieldSubmissionId { get; set; }

        /// <summary>
        /// The name of the submitted form field
        /// </summary>
        public string FormFieldName { get; set; }

        /// <summary>
        /// The value of the submitted form field
        /// </summary>
        public string FormFieldValue { get; set; }

        /// <summary>
        /// The type of the input
        /// </summary>
        public FormInputType FormInputType { get; set; }

        /// <summary>
        /// The form submission this field belongs to
        /// </summary>
        public FormSubmission FormSubmission { get; set; }

        /// <summary>
        /// The id of the form submission
        /// </summary>
        public string FormSubmissionId { get; set; }
    }
}