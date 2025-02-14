using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Models;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration:BaseEntityConfiguration<Appointment>
{
    public override void Configure(EntityTypeBuilder<Appointment> builder)
    {
        base.Configure(builder);

        base.Configure(builder);

        builder.Property(a => a.AppointmentDateTime)
               .IsRequired();

        builder.Property(a => a.Duration)
               .IsRequired();

        builder.Property(a => a.Status)
               .IsRequired()
               .HasConversion<int>();

        builder.Property(a => a.Notes)
               .HasMaxLength(1000);

        builder.Property(a => a.CancellationReason)
               .HasMaxLength(500);

        builder.Property(a => a.ConsultationFee)
               .HasPrecision(10, 2);

        builder.Property(a => a.IsPaid)
               .IsRequired();

        builder.HasOne(a => a.Patient)
               .WithMany(p => p.Appointments)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Treatment)
               .WithOne(t => t.Appointment)
               .HasForeignKey<Treatment>(t => t.AppointmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
