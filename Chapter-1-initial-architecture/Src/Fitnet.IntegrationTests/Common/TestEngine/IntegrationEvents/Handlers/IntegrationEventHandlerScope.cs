namespace EvolutionaryArchitecture.Fitnet.IntegrationTests.Common.TestEngine.IntegrationEvents.Handlers;

using BeautifulEvents;
using MediatR;

internal sealed class IntegrationEventHandlerScope<TIntegrationEvent> : IDisposable
where TIntegrationEvent : IIntegrationEvent
{
    private readonly IServiceScope _serviceScope;
    internal readonly IIntegrationEventProcessor<TIntegrationEvent> IntegrationEventProcessor;

    public IntegrationEventHandlerScope(WebApplicationFactory<Program> applicationInMemoryFactory)
    {
        _serviceScope = applicationInMemoryFactory.Services.CreateScope();
        IntegrationEventProcessor = (IIntegrationEventProcessor<TIntegrationEvent>)_serviceScope
            .ServiceProvider
            .GetRequiredService<INotificationHandler<TIntegrationEvent>>();
    }

    public async Task Consume(TIntegrationEvent @event, CancellationToken cancellationToken = default) =>
        await IntegrationEventProcessor.Handle(@event, cancellationToken);

    public void Dispose() =>
        _serviceScope.Dispose();
}
