namespace EvolutionaryArchitecture.Passes.Application.UseCases.GetAllPasses;

using Dtos;

public record GetAllPassesResponse(IReadOnlyCollection<PassDto> Passes)
{
    internal static GetAllPassesResponse Create(IReadOnlyCollection<PassDto> passes) => new(passes);
}
