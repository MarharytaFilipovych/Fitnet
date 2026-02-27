namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class PassRegistrationSagaEntityConfiguration : IEntityTypeConfiguration<PassRegistrationSaga>
{
    public void Configure(EntityTypeBuilder<PassRegistrationSaga> builder)
    {
        builder.ToTable("PassRegistrationSagas");
        builder.HasKey(x => x.SagaId);
        builder.Property(x => x.PassId).IsRequired();
        builder.Property(x => x.Status)
            .HasConversion<string>()
            .IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.HasIndex(x => x.PassId).IsUnique();
    }
}

