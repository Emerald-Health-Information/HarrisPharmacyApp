using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarrisPharmacy.App.Data.Enums;

namespace HarrisPharmacy.App.Data.Entities.Forms
{
    /// <summary>
    /// Represents A field of a form
    /// </summary>
    public class FormField : BaseEntity
    {
        /// <summary>
        /// Primary key0
        /// </summary>
        public string FormFieldId { get; set; }

        /// <summary>
        /// Foreign key
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// The form this form field belongs to - reference navigation property
        /// </summary>
        public Form Form { get; set; }

        /// <summary>
        /// The type of input
        /// </summary>
        public FormInputType FormInputType { get; set; }
    }
}