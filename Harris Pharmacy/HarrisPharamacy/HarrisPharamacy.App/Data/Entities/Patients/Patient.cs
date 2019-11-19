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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Entities.Patients
{
    /// <summary>
    /// Represents a patient
    /// </summary>
    public class Patient : BaseEntity
    {
        /// <summary>
        /// Primary key for patients
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// First name of a patient
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of a patient
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Age of a patient
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Mental status of a patient
        /// </summary>
        public string MentalStatus { get; set; }

        /// <summary>
        /// Sex of patient
        /// </summary>
        public string Sex { get; set; }
    }
}