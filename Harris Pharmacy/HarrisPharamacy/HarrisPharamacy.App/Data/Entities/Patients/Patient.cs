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
    }
}
