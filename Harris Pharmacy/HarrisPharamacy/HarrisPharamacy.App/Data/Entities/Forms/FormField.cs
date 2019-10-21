using HarrisPharmacy.App.Data.Enums;
using System.Collections.Generic;

namespace HarrisPharmacy.App.Data.Entities.Forms
{
    /// <summary>
    /// Represents A field of a form
    /// </summary>
    public class FormField : BaseEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public string FormFieldId { get; set; }

        /// <summary>
        /// The type of input
        /// </summary>
        public FormInputType FormInputType { get; set; }

        /// <summary>
        /// The given name of the field
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// This property determines if this field has to use certain values and not just user input
        /// </summary>
        public bool UseValues { get; set; }

        /// <summary>
        /// If use values is true, this will contain the list of values seperated by commas
        /// </summary>
        public string Values { get; set; }

        /// <summary>
        /// A list to the formWithFields that it belongs too
        /// </summary>
        public List<FormWithFields> FormWithFields { get; set; }
    }
}