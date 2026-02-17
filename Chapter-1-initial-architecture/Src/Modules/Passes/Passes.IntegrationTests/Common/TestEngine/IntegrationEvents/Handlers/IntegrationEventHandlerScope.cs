namespace EvolutionaryArchitecture.Passes.IntegrationTests.Common.TestEngine.IntegrationEvents.Handlers;

using Fitnet.BeautifulEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

internal sealed class IntegrationEventHandlerScope<TIntegrationEvent> : IDisposable
where TIntegrationEvent : IIntegrationEvent
{
    private readonly IServiceScope _serviceScope;
    private readonly IIntegrationEventProcessor<TIntegrationEvent> _integrationEventProcessor;

    public IntegrationEventHandlerScope(WebApplicationFactory<Program> applicationInMemoryFactory)
    {
        _serviceScope = applicationInMemoryFactory.Services.CreateScope();
        _integrationEventProcessor = (IIntegrationEventProcessor<TIntegrationEvent>)_serviceScope
            .ServiceProvider
            .GetRequiredService<INotificationHandler<TIntegrationEvent>>();
    }

    public async Task Consume(TIntegrationEvent @event, CancellationToken cancellationToken = default) =>
        await _integrationEventProcessor.Handle(@event, cancellationToken);

    public void Dispose() =>
        _serviceScope.Dispose();
}
