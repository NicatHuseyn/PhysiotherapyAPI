namespace PhysiothreapyApp.Domain.Abstractions;

public abstract class Entity:IEntityTimeStamps
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public DateOnly CreatedDate { get; set; }
    public DateOnly? UpdateddDate { get; set; }
    public DateOnly? DeletedDate { get; set; }
}
