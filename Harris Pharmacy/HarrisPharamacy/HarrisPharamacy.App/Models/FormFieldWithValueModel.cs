/*

Harrison1 COSC 471 2019

File = FormFieldWithValueModel.cs

Author = Taylor Adam

Date = 2020 - 01 - 10

License = MIT

            Modification History

Version     Author Date           Desc
v 1.0		Taylor Adam     2020-01-20			Created

*/
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