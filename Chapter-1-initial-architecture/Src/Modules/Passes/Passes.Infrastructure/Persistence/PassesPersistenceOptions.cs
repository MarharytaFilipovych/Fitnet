namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using System.ComponentModel.DataAnnotations;

internal sealed class PassesPersistenceOptions
{
    public const string SectionName = "ConnectionStrings";

    [Required] public string Passes { get; init; } = string.Empty;
}
