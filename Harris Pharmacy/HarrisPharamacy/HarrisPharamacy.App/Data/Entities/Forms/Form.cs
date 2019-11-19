#region copyright

/*

Harrison1 COSC 470 2019

File = Form.cs

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
}