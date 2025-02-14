using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Models;

public class Exercise : Entity
{
    public Guid TreatmentId { get; set; }
    public virtual Treatment Treatment { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Instructions { get; set; } = default!;
    public string Duration { get; set; } = default!;
    public int? RepetitionsCount { get; set; }
    public int? SetsCount { get; set; }

    public string? VideoUrl { get; set; }
    public string? ImageUrl { get; set; }
}
