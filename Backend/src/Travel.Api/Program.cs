using Travel.Application.Services.Auth;
using Travel.Application;
using Travel.DataAccess;
using Microsoft.AspNetCore.Mvc;

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
    [FromBody] RegisterDto register,
    [FromServices] IAuthService service, 
    HttpRequest request,
    CancellationToken token) =>
{
    int id = await service.TryRigisterAsync(register, token);

    return Results.Accepted($"{request.Scheme}://{request.Host}{request.Path}");
});

await app.Services.ApplyMigrations();

app.Run();
