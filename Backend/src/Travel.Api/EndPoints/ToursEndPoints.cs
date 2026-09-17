using Microsoft.AspNetCore.Mvc;
using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Application.Services.Tours.PrimaryAggreements;

namespace Travel.Api.EndPoints
{
    public static class ToursEndPoints
    {
        public static WebApplication AddToursEndPoints(this WebApplication app)
        {
            var apiGroup = app.MapGroup("api/staff/tours");

            var btcGroup = apiGroup.MapGroup("btc");

            btcGroup.MapPost("/aggreements", async (CreateBTCAggrementDto data, [FromServices] IPrimaryAggreementsService service, CancellationToken token) =>
            {
                var result = await service.CreateBTCAsync(data, token);

                return Results.Ok(result);
            }).RequireAuthorization(policy => policy.RequireRole("Manager", "Agent"));

            btcGroup.MapGet("/aggreements/all", async ([FromServices] IPrimaryAggreementsService service, CancellationToken token) =>
            {
                var result = await service.GetAllBTCAsync(token);

                return Results.Ok(result);
            }).RequireAuthorization(policy => policy.RequireRole("Manager"));

            btcGroup.MapGet("/aggreements/{id}", async ([FromServices] IPrimaryAggreementsService service, long id, CancellationToken token) =>
            {
                var result = await service.GetBTCAsync(id, token);

                if (!result.IsSuccess)
                    return Results.NotFound(result.ErrorMessage);

                return Results.Ok(result.Value);
            }).RequireAuthorization(policy => policy.RequireRole("Manager"));

            return app;
        }
    }
}
