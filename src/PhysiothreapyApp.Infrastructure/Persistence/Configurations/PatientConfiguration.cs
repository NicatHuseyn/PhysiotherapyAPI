using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Models;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class PatientConfiguration:BaseEntityConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Surname)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.InsuranceProvider)
            .HasMaxLength(100);

        builder.Property(p => p.InsurancePolicyNumber)
            .HasMaxLength(50);

        builder.Property(p => p.Gender)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.EmergencyContactName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.EmergencyContactPhone)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(p => p.MedicalHistory)
            .WithOne(mh => mh.Patient)
            .HasForeignKey<MedicalHistory>(mh => mh.PatientId);

        builder.HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Treatments)
            .WithOne(t => t.Patient)
            .HasForeignKey(t => t.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Documents)
            .WithOne(d => d.Patient)
            .HasForeignKey(d => d.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
