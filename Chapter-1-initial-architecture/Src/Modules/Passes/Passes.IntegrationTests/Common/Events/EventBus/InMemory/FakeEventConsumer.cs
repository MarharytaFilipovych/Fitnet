namespace EvolutionaryArchitecture.Passes.IntegrationTests.Common.Events.EventBus.InMemory;

using Fitnet.BeautifulEvents;

internal sealed class TestEventConsumer : IIntegrationEventProcessor<FakeEvent>
{
    public Task Handle(FakeEvent @event, CancellationToken cancellationToken)
    {
        @event.MarkAsConsumed();
        return Task.CompletedTask;
    }
}
