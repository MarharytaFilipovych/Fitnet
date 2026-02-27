namespace EvolutionaryArchitecture.Passes.Application.UseCases.GetAllPasses;

using Contracts;
using Dtos;

public sealed class GetAllPasses(IPassRepository repository)
{
    public async Task<GetAllPassesResponse> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var passes = await repository.GetAllAsync(cancellationToken);
        var passDtos = passes.Select(PassDto.From).ToList();
        return new GetAllPassesResponse(passDtos);
    }
}
