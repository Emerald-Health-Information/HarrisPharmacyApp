using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Entities.Forms
{
    /// <summary>
    /// The bridge table for the forms
    /// </summary>
    public class FormWithFields : BaseEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        public string FormWithFieldsId { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// Navigation Property
        /// </summary>
        public Form Form { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        public string FormFieldId { get; set; }

        /// <summary>
        /// Navigation Property
        /// </summary>
        public FormField FormField { get; set; }
    }
}