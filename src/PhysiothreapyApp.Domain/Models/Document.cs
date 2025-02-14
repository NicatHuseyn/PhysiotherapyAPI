using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Models;

public class Document : Entity
{
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; } = default!;

    public Guid? TreatmentId { get; set; }
    public virtual Treatment Treatment { get; set; } = default!;

    public string FileName { get; set; } = default!;
    public string FileType { get; set; } = default!;
    public string FileUrl { get; set; } = default!;
    public string Description { get; set; } = default!;
}
