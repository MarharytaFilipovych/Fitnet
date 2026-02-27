namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;

internal sealed class PassesDbContext(DbContextOptions<PassesDbContext> options) : DbContext(options)
{
    private const string Schema = "Passes";

    public DbSet<Pass> Passes => Set<Pass>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
    public DbSet<PassRegistrationSaga> PassRegistrationSagas => Set<PassRegistrationSaga>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new PassEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PassRegistrationSagaEntityConfiguration());
    }
}
