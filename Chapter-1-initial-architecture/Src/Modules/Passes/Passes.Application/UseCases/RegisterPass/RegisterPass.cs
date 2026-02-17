namespace EvolutionaryArchitecture.Passes.Application.UseCases.RegisterPass;

using Domain;
using Events;
using Contracts;
using Fitnet.BeautifulEvents;

public sealed class RegisterPass(IPassRepository repository, IEventBus eventBus)
{
    public async Task ExecuteAsync(RegisterPassRequest request, CancellationToken cancellationToken = default)
    {
        var pass = Pass.Register(request.CustomerId, request.From, request.To);
        await repository.AddAsync(pass, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        var passRegisteredEvent = PassRegisteredEvent.Create(pass.Id);
        await eventBus.PublishAsync(passRegisteredEvent, cancellationToken);
    }
}
