namespace EvolutionaryArchitecture.Passes.Domain;

public enum PassRegistrationSagaStatus
{
    Started,
    Completed,
    Failed
}

public sealed class PassRegistrationSaga
{
    public Guid SagaId { get; private init; }
    public Guid PassId { get; private init; }
    public PassRegistrationSagaStatus Status { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public DateTime UpdatedAt { get; private set; }

    private PassRegistrationSaga() { }

    public static PassRegistrationSaga Start(Guid passId) => new()
    {
        SagaId = Guid.NewGuid(),
        PassId = passId,
        Status = PassRegistrationSagaStatus.Started,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    public void Complete()
    {
        if (Status == PassRegistrationSagaStatus.Completed)
        {
            return;
        }

        Status = PassRegistrationSagaStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Fail()
    {
        if (Status == PassRegistrationSagaStatus.Completed)
        {
            return;
        }

        Status = PassRegistrationSagaStatus.Failed;
        UpdatedAt = DateTime.UtcNow;
    }
}
