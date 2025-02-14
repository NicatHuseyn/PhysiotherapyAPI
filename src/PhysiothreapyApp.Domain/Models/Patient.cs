using PhysiothreapyApp.Domain.Abstractions;
using PhysiothreapyApp.Domain.Enums;

namespace PhysiothreapyApp.Domain.Models;

public class Patient : Entity
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string InsuranceProvider { get; set; } = default!;
    public string InsurancePolicyNumber { get; set; } = default!;
    public DateTime? InsuranceExpiryDate { get; set; }
    public Gender Gender { get; set; }
    public BloodGroup? BloodGroup { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }

    public virtual MedicalHistory? MedicalHistory { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; } = default!;
    public virtual ICollection<Treatment> Treatments { get; set; } = default!;
    public virtual ICollection<Document> Documents { get; set; } = default!;
}
