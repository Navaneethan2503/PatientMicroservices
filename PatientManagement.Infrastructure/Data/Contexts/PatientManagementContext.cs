using Microsoft.EntityFrameworkCore;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagement.Infrastructure.Data.Contexts
{
    public class PatientManagementContext : DbContext
    {

        public PatientManagementContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PatientManagementContext).Assembly);
        }
    }
}
