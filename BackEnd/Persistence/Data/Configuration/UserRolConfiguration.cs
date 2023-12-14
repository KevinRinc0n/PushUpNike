using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
{
    public void Configure(EntityTypeBuilder<UserRol> builder)
    {
        builder.ToTable("usersRols");

        builder.Property(c => c.IdRolFk)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(c => c.IdUsuarioFk)
        .IsRequired()
        .HasColumnType("int");
    }
}