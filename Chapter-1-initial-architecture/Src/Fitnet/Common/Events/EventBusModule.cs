namespace EvolutionaryArchitecture.Fitnet.Common.Events;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

internal static class EventBusModule
{
    internal static IServiceCollection AddEventBus(this IServiceCollection services) =>
        services.AddInMemoryEventBus(Assembly.GetExecutingAssembly());
}

