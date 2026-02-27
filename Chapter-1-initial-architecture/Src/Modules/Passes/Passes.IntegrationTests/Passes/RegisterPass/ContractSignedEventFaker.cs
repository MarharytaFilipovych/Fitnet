namespace EvolutionaryArchitecture.Passes.IntegrationTests.Passes.RegisterPass;

using Bogus;
using Fitnet.BeautifulEvents;

internal sealed class ContractSignedEventFaker : Faker<ContractSignedEvent>
{
    private ContractSignedEventFaker(DateTimeOffset? validityFrom, DateTimeOffset? validityTo) => CustomInstantiator(
        faker =>
            new ContractSignedEvent(
                faker.Random.Guid(),
                faker.Random.Guid(),
                faker.Random.Guid(),
                validityFrom ?? faker.Date.RecentOffset().ToUniversalTime(),
                validityTo ?? faker.Date.FutureOffset().ToUniversalTime(),
                faker.Date.RecentOffset().ToUniversalTime()
            )
    );

    internal static ContractSignedEvent Create(DateTimeOffset? signedAt = null, DateTimeOffset? expiringAt = null) =>
        new ContractSignedEventFaker(signedAt, expiringAt);
}
