using HarrisPharmacy.App.Data.Entities.Forms;
using HarrisPharmacy.App.Data.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace HarrisPharmacy.App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientList> PatientLists { get; set; }

    }
}