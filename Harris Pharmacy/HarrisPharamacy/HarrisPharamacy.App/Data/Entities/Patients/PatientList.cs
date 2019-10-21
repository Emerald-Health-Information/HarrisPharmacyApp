using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrisPharmacy.App.Data.Entities.Patients
{
    /// <summary>
    /// Represents a single appointment in a list of patients
    /// </summary>
    public class PatientList : BaseEntity
    {
        /// <summary>
        /// Primary key for a patient list item
        /// </summary>
        public string PatientListId { get; set; }
        /// <summary>
        /// Foreign key to patients
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// Foreign key to users
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Starting time for the appointment
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// Ending time for the appointment
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// Location for the appointment
        /// </summary>
        public string Location { get; set; }
    }
}
