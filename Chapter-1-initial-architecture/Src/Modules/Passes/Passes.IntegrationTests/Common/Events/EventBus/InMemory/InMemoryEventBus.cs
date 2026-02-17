namespace EvolutionaryArchitecture.Passes.IntegrationTests.Common.Events.EventBus.InMemory;

using Fitnet.BeautifulEvents;
using MediatR;

internal sealed class InMemoryEventBus(IMediator mediator) : IEventBus
{
    public async Task PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default) where TEvent : IIntegrationEvent =>
        await mediator.Publish(integrationEvent, cancellationToken);
}
