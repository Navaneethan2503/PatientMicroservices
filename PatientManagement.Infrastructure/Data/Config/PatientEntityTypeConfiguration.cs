using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Domain.Aggregates.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagement.Infrastructure.Data.Config
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(m => m.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.PhoneNumber).HasMaxLength(10).IsRequired(true);
            builder.Property(m => m.EmailId).IsRequired(true);
            builder.Property(m => m.DateOfBirth).IsRequired(true);
        }
    }
}
