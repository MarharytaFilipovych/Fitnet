namespace EvolutionaryArchitecture.Passes.Infrastructure.Persistence;

using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

internal sealed partial class OutboxProcessor(
    IServiceScopeFactory scopeFactory,
    ILogger<OutboxProcessor> logger) : BackgroundService
{
    private static readonly TimeSpan Interval = TimeSpan.FromSeconds(10);

    [LoggerMessage(Level = LogLevel.Information, Message = "Processing outbox message {Id} of type {Type}: {Payload}")]
    private partial void LogProcessing(Guid id, string type, string payload);

    [LoggerMessage(Level = LogLevel.Information, Message = "Outbox message {Id} processed successfully.")]
    private partial void LogProcessed(Guid id);

    [LoggerMessage(Level = LogLevel.Error, Message = "Failed to process outbox message {Id}.")]
    private partial void LogFailed(Exception ex, Guid id);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessOutboxAsync(stoppingToken);
            await Task.Delay(Interval, stoppingToken);
        }
    }

    private async Task ProcessOutboxAsync(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PassesDbContext>();

        var messages = await context.OutboxMessages
            .Where(m => m.ProcessedAt == null)
            .ToListAsync(cancellationToken);

        foreach (var message in messages)
        {
            try
            {
                LogProcessing(message.Id, message.Type, message.Payload);

                var saga = await context.PassRegistrationSagas
                    .FirstOrDefaultAsync(s => s.Status == PassRegistrationSagaStatus.Started, cancellationToken);

                saga?.Complete();

                message.MarkAsProcessed();
                await context.SaveChangesAsync(cancellationToken);

                LogProcessed(message.Id);
            }
            catch (Exception ex)
            {
                LogFailed(ex, message.Id);

                var saga = await context.PassRegistrationSagas
                    .FirstOrDefaultAsync(s => s.Status == PassRegistrationSagaStatus.Started, cancellationToken);
                saga?.Fail();
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
