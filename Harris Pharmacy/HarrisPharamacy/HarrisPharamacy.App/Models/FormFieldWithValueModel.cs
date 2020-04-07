using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

using HarrisPharmacy.Data.Entities.Forms;

namespace HarrisPharmacy.App.Models
{
    /// <summary>
    /// A model for storing a formfield and their respective value together, for form submission
    /// </summary>
    public class FormFieldWithValueModel : IEquatable<FormFieldWithValueModel>
    {
        public FormField FormField { get; set; }

        public string Value { get; set; } = null;

        public bool Equals(FormFieldWithValueModel other)
        {
            if (other == null) return false;
            return (this.FormField.FormFieldId.Equals(other.FormField.FormFieldId));
        }
    }
}