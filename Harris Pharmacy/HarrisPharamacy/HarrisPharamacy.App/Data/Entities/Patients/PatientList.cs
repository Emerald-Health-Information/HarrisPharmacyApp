using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Entities.Patients
{
    /// <summary>
    /// Represents a single record in a list of patients.
    /// USed so the user know where and when the meeting/appointment will take place.
    /// </summary>
    public class PatientList : BaseEntity
    {
        public string PatientListId { get; set; }
        /// <summary>
        /// Foreign key from the patient table
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// Foreign key from the user table
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Start time for a meeting/appointment
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// End time for a meeting/appointment
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// Location that the meeting/appointment is happening in.
        /// </summary>
        public string Location { get; set; }

    }
}
