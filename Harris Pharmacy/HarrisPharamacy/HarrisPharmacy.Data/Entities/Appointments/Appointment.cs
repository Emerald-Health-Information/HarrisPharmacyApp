/*

   Harrison1 COSC 471 2019

   File = Appointments.cs

   Author =

   Date = 2020 - 01 - 10

   License = MIT

               Modification History

   Version     Author Date           Desc
   v 1.0		Brandon Chesley    2020-01-20			Added Headers

*/
using System;

namespace HarrisPharmacy.Data.Entities.Appointments
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
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Ending time for the appointment
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Location for the appointment
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The state of the appointment "open, skipped, finished"
        /// </summary>
        public string AppointmentState { get; set; }

        /// <summary>
        /// Returns the duration of the appointment
        /// </summary>
        public int DurationInSeconds { get; set; }
    }
}