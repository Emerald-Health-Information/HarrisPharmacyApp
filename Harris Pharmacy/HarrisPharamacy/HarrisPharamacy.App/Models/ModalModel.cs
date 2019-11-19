#region copyright

/*

Harrison1 COSC 470 2019

File =

Author =

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

using System;

namespace HarrisPharmacy.App.Models
{
    /// <summary>
    /// Represents a Modal object
    /// </summary>
    public class ModalModel
    {
        /// <summary>
        /// Title to be displayed on the Modal
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Message to be displayed on the Modal
        /// </summary>
        public string Message { get; set; }
    }
}