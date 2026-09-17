using Microsoft.AspNetCore.Mvc;
using Travel.Application.Services.Auth;

namespace Travel.Api.EndPoints
{
    public static class AuthEndPoints
    {
        public static WebApplication AddAuthEndPoints(this WebApplication app)
        {
            var apiGroup = app.MapGroup("api/auth");

            apiGroup.MapPost("/register", async (
                [FromBody] SignUpDto register,
                [FromServices] IAuthService service,
                HttpRequest request,
                CancellationToken token) =>
            {
                var result = await service.SignUpAsync(register, token);

                switch (result.Value)
                {
                    case 200:
                        return Results.Ok();

                    case 404:
                        return Results.NotFound(result.ErrorMessage);

                    case 409:
                        return Results.Conflict(result.ErrorMessage);

                    default:
                        return Results.InternalServerError(result.ErrorMessage);
                }
            });


            apiGroup.MapPost("/login", async (
                [FromBody] LoginDto login,
                [FromServices] IAuthService service,
                HttpRequest request,
                CancellationToken token) =>
            {
                var result = await service.LoginAsync(login, token);

                if (result.IsSuccess)
                    return Results.Ok(result.Value);

                return Results.NotFound();
            });

            return app;
        }
    }
}
