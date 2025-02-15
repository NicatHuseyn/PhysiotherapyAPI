﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhysiothreapyApp.Domain.Models.IdentityModels;

namespace PhysiothreapyApp.Infrastructure.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u=>u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u=>u.LastName).IsRequired().HasMaxLength(50);
    }
}
