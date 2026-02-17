namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;

internal sealed class PassesDbContext(DbContextOptions<PassesDbContext> options) : DbContext(options)
{
    private const string Schema = "Passes";

    public DbSet<Pass> Passes => Set<Pass>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new PassEntityConfiguration());
    }
}
