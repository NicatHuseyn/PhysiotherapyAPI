namespace PhysiothreapyApp.Domain.Abstractions;

public class EntityDto
{
    public Guid Id { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
}
