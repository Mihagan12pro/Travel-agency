using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Services.Admin;
using Travel.Application.Services.Auth;
using Travel.Application.Services.Security;
using Travel.Application.Services.Tours.PrimaryAggreements;

namespace Travel.Application;
public static class DependenciesInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISecurityService, SecurityService>();
        services.AddScoped<IAdminService, AdminService>();

        services.AddScoped<IPrimaryAggreementsService, PrimaryAggreementsService>();

        return services;
    }
}