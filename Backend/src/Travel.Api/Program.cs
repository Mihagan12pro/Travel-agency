using Microsoft.AspNetCore.Mvc;
using Travel.Application;
using Travel.Application.DTOs.Employee;
using Travel.Application.Services.Admin;
using Travel.Application.Services.Auth;
using Travel.DataAccess;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = Environment.GetEnvironmentVariable("TravelDb");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddDbServices(connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/auth/register", async (
    [FromBody] SignUpDto register,
    [FromServices] IAuthService service, 
    HttpRequest request,
    CancellationToken token) =>
{
    //int id = await service.TryRigisterAsync(register, token);

    return Results.Accepted($"{request.Scheme}://{request.Host}{request.Path}");
});

app.MapPost("/admin/employees/add", async (ICAOEmployeeDataDto data, [FromServices] IAdminService service, CancellationToken token) => 
{
    await service.AddEmployeeAsync(data, token);
});

await app.Services.ApplyMigrations();

app.Run();
