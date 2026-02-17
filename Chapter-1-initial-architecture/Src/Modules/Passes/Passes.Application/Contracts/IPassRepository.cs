namespace EvolutionaryArchitecture.Passes.Application.Contracts;

using Domain;

public interface IPassRepository
{
    Task<Pass?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Pass>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Pass pass, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
