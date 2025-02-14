namespace PhysiothreapyApp.Domain.Abstractions;

public interface IEntityTimeStamps
{
    public DateOnly CreatedDate { get; set; }
    public DateOnly? UpdateddDate { get; set; }
    public DateOnly? DeletedDate { get; set; }
}
