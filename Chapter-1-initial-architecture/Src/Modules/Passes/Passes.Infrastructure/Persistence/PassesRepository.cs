namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;

internal sealed class PassRepository(PassesDbContext context) : IPassRepository
{

    public async Task<Pass?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => await context.Passes.FindAsync(
        [id], cancellationToken);

    public async Task<IReadOnlyList<Pass>> GetAllAsync(CancellationToken cancellationToken = default) => await context.Passes
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task AddAsync(Pass pass, CancellationToken cancellationToken = default) => await context.Passes
        .AddAsync(pass, cancellationToken);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await context
        .SaveChangesAsync(cancellationToken);
}
