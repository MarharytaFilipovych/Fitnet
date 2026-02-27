namespace EvolutionaryArchitecture.Fitnet.BeautifulEvents;

using MediatR;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; }
    DateTimeOffset OccurredDateTime { get; }
}
