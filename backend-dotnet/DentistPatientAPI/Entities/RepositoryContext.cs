using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
            {
            }

            public DbSet<Dentist> Dentists { get; set; }
            public DbSet<Patient> Patients { get; set; }
            public DbSet<Appointment> Appointments { get; set; }

    }
}