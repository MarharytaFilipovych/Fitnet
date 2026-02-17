namespace EvolutionaryArchitecture.Passes.IntegrationTests.Common.TestEngine.Time;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

internal static class TimeExtensions
{
    internal static WebApplicationFactory<T> WithTime<T>(
        this WebApplicationFactory<T> webApplicationFactory, FakeTimeProvider fakeSystemTimeProvider)
        where T : class => webApplicationFactory
        .WithWebHostBuilder(builder => builder.ConfigureTestServices(services => services.AddSingleton<TimeProvider>(fakeSystemTimeProvider)));
}
