using Microsoft.AspNetCore.Mvc;
using Travel.Application.Services.Auth;
using Travel.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
string? connectionString = builder.Configuration["TravelDb"];


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

app.Run();
