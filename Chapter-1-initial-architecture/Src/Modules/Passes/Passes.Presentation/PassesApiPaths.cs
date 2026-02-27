namespace EvolutionaryArchitecture.Passes.Presentation;

public static class PassesApiPaths
{
    private const string Root = "api";

    public const string GetAll = $"{Root}/passes";
    public const string MarkPassAsExpired = $"{Root}/passes/{{id}}";
}
