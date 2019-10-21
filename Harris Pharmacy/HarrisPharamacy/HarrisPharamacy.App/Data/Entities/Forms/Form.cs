using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Enums;

namespace HarrisPharmacy.App.Data.Entities.Forms
{
    /// <summary>
    /// Represents a form
    /// </summary>
    public class Form : BaseEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// Name of the form
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The id of the form creator - may not be used right away
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// The list of form fields that use this form this form uses - reference navigation property
        /// </summary>
        public List<FormWithFields> FormWithFields { get; set; }
    }

    /// <summary>
    /// The bridge table for the forms
    /// </summary>
    public class FormWithFields : BaseEntity
    {
        public string FormWithFieldsId { get; set; }
        public string FormId { get; set; }
        public Form Form { get; set; }
        public string FormFieldId { get; set; }
        public FormField FormField { get; set; }
    }
}