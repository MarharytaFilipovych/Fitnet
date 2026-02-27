namespace EvolutionaryArchitecture.Fitnet.Common.Events;

using BeautifulEvents;
using MediatR;

internal sealed class InMemoryEventBus(IMediator mediator) : IEventBus
{
    public async Task PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default) where TEvent : IIntegrationEvent =>
        await mediator.Publish(integrationEvent, cancellationToken);
}
