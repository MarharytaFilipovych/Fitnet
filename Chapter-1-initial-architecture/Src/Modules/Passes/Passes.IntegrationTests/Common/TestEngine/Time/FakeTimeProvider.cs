namespace EvolutionaryArchitecture.Passes.IntegrationTests.Common.TestEngine.Time;

using Bogus;
using JetBrains.Annotations;

[UsedImplicitly]
internal sealed class FakeTimeProvider(DateTimeOffset? now = null) : TimeProvider
{
    private DateTimeOffset TimeNowOffset { get; set; } = now ?? new Faker().Date.RecentOffset().UtcDateTime;

    public override DateTimeOffset GetUtcNow() => TimeNowOffset;
}
