namespace EvolutionaryArchitecture.Passes.Application.UseCases.RegisterPass;

using Domain;
using Contracts;

public sealed class RegisterPass(IPassRepository repository)
{
    private const string EventName = "PassRegistered";
    public async Task ExecuteAsync(RegisterPassRequest request, CancellationToken cancellationToken = default)
    {
        var pass = Pass.Register(request.CustomerId, request.From, request.To);
        var payload = $"{EventName}:{pass.Id}";
        var outboxMessage = OutboxMessage.Create(EventName, payload);
        var saga = PassRegistrationSaga.Start(pass.Id);
        await repository.AddAsync(pass, outboxMessage, saga, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
