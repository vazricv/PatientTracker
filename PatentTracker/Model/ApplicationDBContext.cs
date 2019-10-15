
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatentTracker.Model
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Stage> Stage { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientLog> PatientLogs { get; set; }

    }
}
