using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using System.Text.Json;
using Travel.Api.EndPoints;
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

app.AddAuthEndPoints();
app.AddAdminEndPoints();
app.AddToursEndPoints();

await app.Services.ApplyMigrations();

app.Run();
