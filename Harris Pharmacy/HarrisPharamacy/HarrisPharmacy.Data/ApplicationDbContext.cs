#region copyright

/*

Harrison1 COSC 470 2019

File = ApplicationDbContext.cs

Author = Taylor Adam

Date = 2019-11-19

License = MIT

				Modification History

Version		Author			Date				Desc
v 1.0		Taylor Adam		2019-11-19			Added Headers

*/

#endregion copyright

using HarrisPharmacy.Data.Entities.Appointments;
using HarrisPharmacy.Data.Entities.Forms;
using HarrisPharmacy.Data.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace HarrisPharmacy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }

        public DbSet<FormWithFields> FormWithFields { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientList> PatientLists { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}