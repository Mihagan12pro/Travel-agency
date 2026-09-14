using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Services.Admin;
using Travel.Application.Services.Auth;
using Travel.Application.Services.Security;

namespace Travel.Application;
public static class DependenciesInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISecurityService, SecurityServiceV1>();
        services.AddScoped<IAdminService, AdminService>();

        return services;
    }
}