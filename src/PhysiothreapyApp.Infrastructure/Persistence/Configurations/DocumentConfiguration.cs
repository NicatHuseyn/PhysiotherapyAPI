using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Models;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class DocumentConfiguration:BaseEntityConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.FileName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(d => d.FileType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.FileUrl)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(d => d.Description)
               .HasMaxLength(1000);

        builder.HasOne(d => d.Patient)
               .WithMany(p => p.Documents)
               .HasForeignKey(d => d.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Treatment)
               .WithMany(t => t.Documents)
               .HasForeignKey(d => d.TreatmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
