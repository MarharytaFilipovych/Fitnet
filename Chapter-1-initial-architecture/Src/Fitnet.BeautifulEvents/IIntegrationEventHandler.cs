namespace EvolutionaryArchitecture.Fitnet.BeautifulEvents;

using MediatR;

public interface IIntegrationEventProcessor<in TEvent> : INotificationHandler<TEvent> where TEvent : IIntegrationEvent;
