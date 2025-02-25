using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Models;

public class Treatment : Entity
{
    public Guid PatientId { get; set; }

    public virtual Patient Patient { get; set; } = default!;

    public Guid AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; } = default!;

    public string Diagnosis { get; set; } = default!;

    public string TreatmentPlan { get; set; } = default!;

    public DateTime Date { get; set; }

    public string Progress { get; set; } = default!;

    public string? Notes { get; set; }

    public DateTime? NextAppointmentDate { get; set; }

    public bool RequiresFollowUp { get; set; }

    public virtual ICollection<Exercise>? Exercises { get; set; }
    public virtual ICollection<Document>? Documents { get; set; }
}
