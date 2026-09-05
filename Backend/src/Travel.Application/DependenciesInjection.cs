using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Services.Auth;

namespace Travel.Application;
public static class DependenciesInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}