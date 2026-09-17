using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using System.Text.Json;
using Travel.Application;
using Travel.Application.DTOs.Employee;
using Travel.Application.DTOs.Tours.Aggreement.BTC;
using Travel.Application.Services.Admin;
using Travel.Application.Services.Auth;
using Travel.Application.Services.Security;
using Travel.Application.Services.Tours.PrimaryAggreements;
using Travel.DataAccess;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = Environment.GetEnvironmentVariable("TravelDb");

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidation();

builder.Services.AddApplicationServices();
builder.Services.AddDbServices(connectionString);

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(options =>
{
    var binDirectory = new DirectoryInfo(AppContext.BaseDirectory);
    var files = binDirectory.GetFiles("*.xml");

    foreach (var file in files)
    {
        options.IncludeXmlComments(file.FullName);
    }

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
 {
     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 })
 .AddJwtBearer(options =>
  {
      var jwtVariable = Environment.GetEnvironmentVariable("TravelJwt");
      JwtToken jwtToken = JsonSerializer.Deserialize<JwtToken>(jwtVariable);

      options.MapInboundClaims = false;

      options.TokenValidationParameters = new TokenValidationParameters
      {
          ClockSkew = TimeSpan.Zero,

          ValidateLifetime = true,

          ValidateIssuer = true,

          ValidIssuer = jwtToken.Issuer,

          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(jwtToken.IssuerSigningKey),

          RoleClaimType = "role",

          ValidAudiences = jwtToken.Audiences
      };
  });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); 
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapPost("/auth/register", async (
    [FromBody] SignUpDto register,
    [FromServices] IAuthService service, 
    HttpRequest request,
    CancellationToken token) =>
{
    var result = await service.SignUpAsync(register, token);

    switch(result.Value)
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


app.MapPost("/auth/login", async (
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

app.MapPost("/admin/employees/add", async (EmployeeDataDto data, [FromServices] IAdminService service, CancellationToken token) =>
{

    await service.AddEmployeeAsync(data, token);

}).RequireAuthorization(policy => policy.RequireRole("Admin"));

app.MapPost("staff/tours/btc/aggreements", async (CreateBTCAggrementDto data, [FromServices] IPrimaryAggreementsService service, CancellationToken token) =>
{
    var result = await service.CreateBTCAsync(data, token);

    return Results.Ok(result);
}).RequireAuthorization(policy => policy.RequireRole("Manager", "Agent"));

app.MapGet("staff/tours/btc/aggreements/all", async ([FromServices] IPrimaryAggreementsService service, CancellationToken token) =>
{
    var result = await service.GetAllBTCAsync(token);

    return Results.Ok(result);
}).RequireAuthorization(policy => policy.RequireRole("Manager"));

app.MapGet("staff/tours/btc/aggreements/{id}", async ([FromServices] IPrimaryAggreementsService service, long id, CancellationToken token) =>
{
    var result = await service.GetBTCAsync(id, token);

    if (!result.IsSuccess)
        return Results.NotFound(result.ErrorMessage);

    return Results.Ok(result.Value);
}).RequireAuthorization(policy => policy.RequireRole("Manager"));

await app.Services.ApplyMigrations();

app.Run();
