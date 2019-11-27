using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HarrisPharmacy.App.Data.Entities.Appointments
{
    public class Appointment : BaseEntity
    {
        /// <summary>
        /// Primary key for a patient list item
        /// </summary>
        public string AppointmentId { get; set; }
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
        /// <summary>
        /// The state of the appointment "open, skipped, finished"
        /// </summary>
        public string AppointmentState { get; set; }
    }
}