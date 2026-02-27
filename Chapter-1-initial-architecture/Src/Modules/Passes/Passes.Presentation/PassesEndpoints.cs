namespace EvolutionaryArchitecture.Passes.Presentation;

using Application.UseCases.GetAllPasses;
using Application.UseCases.MarkPassAsExpired;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public static class PassesEndpoints
{
    private const string BaseRoute = "api/passes";
    private const string GetAllPassesName = "GetAllPasses";
    private const string MarkPassAsExpiredName = "MarkPassAsExpired";

    public static void MapPasses(this IEndpointRouteBuilder app)
    {
        app.MapGetAllPasses();
        app.MapMarkPassAsExpired();
    }

    private static void MapGetAllPasses(this IEndpointRouteBuilder app) => app.MapGet
        (BaseRoute, async (GetAllPasses getAllPasses, CancellationToken cancellationToken) =>
            {
                var response = await getAllPasses.ExecuteAsync(cancellationToken);
                return Results.Ok(response);
            })
            .WithName(GetAllPassesName)
            .Produces<GetAllPassesResponse>()
            .Produces(StatusCodes.Status500InternalServerError);

    private static void MapMarkPassAsExpired(this IEndpointRouteBuilder app) => app.MapPatch
        ($"{BaseRoute}/{{id}}", async (Guid id, MarkPassAsExpired markPassAsExpired, CancellationToken cancellationToken) =>
            {
                var result = await markPassAsExpired.ExecuteAsync(id, cancellationToken);
                return result.IsNotFound ? Results.NotFound() : Results.NoContent();
            })
        .WithName(MarkPassAsExpiredName)
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError);
}
