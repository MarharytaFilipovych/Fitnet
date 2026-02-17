using EvolutionaryArchitecture.Fitnet.Common.Clock;
using EvolutionaryArchitecture.Fitnet.Common.Documentation;
using EvolutionaryArchitecture.Fitnet.Common.ErrorHandling;
using EvolutionaryArchitecture.Fitnet.Common.Events;
using EvolutionaryArchitecture.Fitnet.Common.Validation.Requests;
using EvolutionaryArchitecture.Fitnet.Contracts;
using EvolutionaryArchitecture.Fitnet.Offers;
using EvolutionaryArchitecture.Fitnet.Reports;
using EvolutionaryArchitecture.Passes.Infrastructure.Dependencies;
using EvolutionaryArchitecture.Passes.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddExceptionHandling();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEventBus();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddRequestsValidations();
builder.Services.AddClock();

builder.Services.AddPassesInfrastructure(builder.Configuration);
builder.Services.AddPassesApplication();
builder.Services.AddContracts(builder.Configuration);
builder.Services.AddOffers(builder.Configuration);
builder.Services.AddReports(builder.Configuration);

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiDocumentation();
app.Services.UsePasses();
app.UseContracts();
app.UseReports();
app.UseOffers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandling();
app.MapControllers();

app.MapPasses();
app.MapContracts();
app.MapReports();

await app.RunAsync();

namespace EvolutionaryArchitecture.Fitnet
{
    [UsedImplicitly]
    public sealed class Program;
}
