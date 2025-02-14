using PhysiothreapyApp.Domain.Abstractions;
using PhysiothreapyApp.Domain.Enums;

namespace PhysiothreapyApp.Domain.Models;

public class Appointment : Entity
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = default!;

    public DateOnly AppointmentDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public AppointmentStatus Status { get; set; }
    public string Notes { get; set; } = default!;
    public string? CancellationReason { get; set; }
    public decimal? ConsultationFee { get; set; }
    public bool IsPaid { get; set; }

    public virtual Treatment Treatment { get; set; } = default!;
}
