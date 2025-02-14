using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.CreatedDate)
            .IsRequired();


        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}
