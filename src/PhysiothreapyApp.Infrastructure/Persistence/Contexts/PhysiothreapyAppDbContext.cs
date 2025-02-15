using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Domain.Models.IdentityModels;

namespace PhysiothreapyApp.Infrastructure.Persistence.Contexts;

public class PhysiothreapyAppDbContext:IdentityDbContext<AppUser>
{
	public PhysiothreapyAppDbContext(DbContextOptions options):base(options){}
    public PhysiothreapyAppDbContext(){}

    public DbSet<Patient> Patients { get; set; } = default!;
    public DbSet<Doctor> Doctors { get; set; } = default!;
    public DbSet<Appointment> Appointments { get; set; } = default!;
    public DbSet<Treatment> Treatments { get; set; } = default!;
    public DbSet<Exercise> Exercises { get; set; } = default!;
    public DbSet<MedicalHistory> MedicalHistories { get; set; } = default!;
    public DbSet<Document> Documents { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
