namespace EvolutionaryArchitecture.Passes.Application.UseCases.MarkPassAsExpired;

public sealed class MarkPassAsExpiredResult
{
    public bool IsSuccess { get; private init; }
    public bool IsNotFound { get; private init; }

    private MarkPassAsExpiredResult(bool isSuccess, bool isNotFound)
    {
        IsSuccess = isSuccess;
        IsNotFound = isNotFound;
    }

    public static MarkPassAsExpiredResult Success() => new(true, false);
    public static MarkPassAsExpiredResult NotFound() => new(false, true);
}
