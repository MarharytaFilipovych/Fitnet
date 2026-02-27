namespace EvolutionaryArchitecture.Passes.Domain;

public sealed class OutboxMessage
{
    public Guid Id { get; private init; }
    public string Type { get; private init; } = null!;
    public string Payload { get; private init; } = null!;
    public DateTime CreatedAt { get; private init; }
    public DateTime? ProcessedAt { get; private set; }

    private OutboxMessage() { }

    public static OutboxMessage Create(string type, string payload) => new()
    {
        Id = Guid.NewGuid(),
        Type = type,
        Payload = payload,
        CreatedAt = DateTime.UtcNow
    };

    public void MarkAsProcessed() => ProcessedAt = DateTime.UtcNow;
}
