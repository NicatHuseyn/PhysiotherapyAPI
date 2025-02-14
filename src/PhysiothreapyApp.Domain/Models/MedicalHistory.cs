using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Models;

public class MedicalHistory : Entity
{
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; } = default!;

    public string ExistingConditions { get; set; } = default!;
    public string PreviousTreatments { get; set; } = default!;
    public string Allergies { get; set; } = default!;
    public string CurrentMedications { get; set; } = default!;
    public string PastSurgeries { get; set; } = default!;
    public string FamilyHistory { get; set; } = default!;
    public string LifestyleFactors { get; set; } = default!;
    public string OccupationalHazards { get; set; } = default!;
}
