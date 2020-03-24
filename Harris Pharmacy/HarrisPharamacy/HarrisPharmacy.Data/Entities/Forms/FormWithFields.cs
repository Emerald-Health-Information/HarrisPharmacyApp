#region copyright

/*

Harrison1 COSC 470 2019

File = FormWithFields.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

namespace HarrisPharmacy.Data.Entities.Forms
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