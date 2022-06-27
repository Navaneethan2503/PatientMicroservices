using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagement.Infrastructure.Data.Config
{
    public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.PatientId).IsRequired(true);
            builder.Property(m => m.DoctorId).IsRequired(true);
            builder.Property(m => m.DateOfAppointment).IsRequired(true);
            builder.Property(m => m.DepartmentName).HasMaxLength(30).IsRequired();
        }
    }
}
