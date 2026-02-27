namespace EvolutionaryArchitecture.Passes.Application.UseCases.MarkPassAsExpired;

using Contracts;
using Events;
using Fitnet.BeautifulEvents;

public sealed class MarkPassAsExpired(IPassRepository repository,
    IEventBus eventBus, TimeProvider timeProvider)
{
    public async Task<MarkPassAsExpiredResult> ExecuteAsync(
        Guid passId, CancellationToken cancellationToken = default)
    {
        var pass = await repository.GetByIdAsync(passId, cancellationToken);
        if (pass is null)
        {
            return MarkPassAsExpiredResult.NotFound();
        }

        var nowDate = timeProvider.GetUtcNow();
        pass.MarkAsExpired(nowDate);
        await repository.SaveChangesAsync(cancellationToken);

        var passExpiredEvent = PassExpiredEvent.Create(pass.Id, pass.CustomerId, nowDate);
        await eventBus.PublishAsync(passExpiredEvent, cancellationToken);

        return MarkPassAsExpiredResult.Success();
    }
}
