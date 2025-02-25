using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Models;

public class Doctor : Entity
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public string Qualifications { get; set; } = default!;
    public string Biography { get; set; } = default!;
    public string? ProfilePicture { get; set; }
    public bool IsAvailable { get; set; }
    public string? WorkingHours { get; set; }
    public decimal ConsultationFees { get; set; }

    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Treatment>? Treatments { get; set; }
}
