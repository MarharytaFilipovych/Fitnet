namespace EvolutionaryArchitecture.Fitnet.Common.Events;

using System.Reflection;
using BeautifulEvents;
using Microsoft.Extensions.DependencyInjection;

internal static class InMemoryEventBusModule
{
    internal static IServiceCollection AddInMemoryEventBus(this IServiceCollection services, Assembly assembly)
    {
        services.AddScoped<IEventBus, InMemoryEventBus>();
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        return services;
    }
}
