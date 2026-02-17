namespace EvolutionaryArchitecture.Passes.Application.UseCases.RegisterPass;

public sealed record RegisterPassRequest(Guid CustomerId, DateTimeOffset From, DateTimeOffset To);
