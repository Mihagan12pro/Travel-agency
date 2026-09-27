using Microsoft.AspNetCore.Mvc;
using Travel.Application.DTOs.Employee;
using Travel.Application.Services.Admin;

namespace Travel.Api.EndPoints
{
    public static class AdminEndPoints
    {
        public static WebApplication AddAdminEndPoints(this WebApplication app)
        {
            var apiGroup = app.MapGroup("api/admin");

            apiGroup.MapPost("/employees/add", async (EmployeeDataDto data, [FromServices] IAdminService service, CancellationToken token) =>
            {
                await service.AddEmployeeAsync(data, token);

            }).RequireAuthorization(policy => policy.RequireRole("Admin"));

            return app;
        }
    }
}
