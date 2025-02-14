using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Models;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class TreatmentConfiguration:BaseEntityConfiguration<Treatment>
{
    public override void Configure(EntityTypeBuilder<Treatment> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Diagnosis)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(t => t.TreatmentPlan)
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(t => t.Date)
               .IsRequired();

        builder.Property(t => t.Progress)
               .HasMaxLength(500);

        builder.Property(t => t.Notes)
               .HasMaxLength(1000);

        builder.Property(t => t.NextAppointmentDate);

        builder.Property(t => t.RequiresFollowUp)
               .IsRequired();

        builder.HasOne(t => t.Patient)
               .WithMany(p => p.Treatments)
               .HasForeignKey(t => t.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Appointment)
               .WithOne(a => a.Treatment)
               .HasForeignKey<Treatment>(t => t.AppointmentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Exercises)
               .WithOne(e => e.Treatment)
               .HasForeignKey(e => e.TreatmentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Documents)
               .WithOne(d => d.Treatment)
               .HasForeignKey(d => d.TreatmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
