namespace EvolutionaryArchitecture.Passes.Application.Dtos;

using Domain;

public record PassDto(Guid Id, Guid CustomerId)
{
    public static PassDto From(Pass contract) => new(contract.Id, contract.CustomerId);
}
