namespace EvolutionaryArchitecture.Passes.Application.EventProcessors;

using Fitnet.BeautifulEvents;
using UseCases.RegisterPass;

public sealed class ContractSignedEventProcessor(RegisterPass registerPass) : IIntegrationEventProcessor<ContractSignedEvent>
{
    public async Task Handle(ContractSignedEvent notification, CancellationToken cancellationToken)
    {
        var command = new RegisterPassRequest(notification.ContractCustomerId,
            notification.SignedAt, notification.ExpireAt);

        await registerPass.ExecuteAsync(command, cancellationToken);
    }
}
