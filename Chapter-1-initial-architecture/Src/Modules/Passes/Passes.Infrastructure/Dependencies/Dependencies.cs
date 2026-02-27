namespace EvolutionaryArchitecture.Passes.Infrastructure.Dependencies;

using Application.Contracts;
using Application.UseCases.GetAllPasses;
using Application.UseCases.MarkPassAsExpired;
using Application.UseCases.RegisterPass;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence;

public static class Dependencies
{
    public static void AddPassesApplication(this IServiceCollection services)
    {
        services.AddScoped<GetAllPasses>();
        services.AddScoped<MarkPassAsExpired>();
        services.AddScoped<RegisterPass>();
    }

    public static void UsePasses(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PassesDbContext>();
        context.Database.Migrate();
    }

    public static void AddPassesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PassesPersistenceOptions>(
            configuration.GetSection(PassesPersistenceOptions.SectionName));
        services.AddOptionsWithValidateOnStart<PassesPersistenceOptions>();

        services.AddDbContext<PassesDbContext>((serviceProvider, options) =>
        {
            var persistenceOptions = serviceProvider
                .GetRequiredService<IOptions<PassesPersistenceOptions>>();
            var connectionString = persistenceOptions.Value.Passes;
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IPassRepository, PassRepository>();

        services.AddHostedService<OutboxProcessor>();
    }
}
