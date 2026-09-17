using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Services.Admin;
using Travel.Application.Services.Clients;
using Travel.Application.Services.Tours.PrimaryAggreements;
using Travel.Application.Services.Users;
using Travel.DataAccess.Repositories;

namespace Travel.DataAccess
{
    public static class DependenciesInjection
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>((options) => 
            {
                options.UseNpgsql(connectionString,
                npgsql =>
                {
                    var assemblyName = typeof(AppDbContext)
                       .Assembly
                       .GetName()
                       .Name;

                    npgsql.MigrationsAssembly(assemblyName);
                });
            });

            services.AddScoped<IEmployeesRepository, EmployeesRepositoryV1>();
            services.AddScoped<IAuthRepository, AuthRepositoryV1>();
            services.AddScoped<IPrimaryAggreementsRepository, PrimaryAggreementsRepositoryV1>();
            
            services.AddScoped<IUsersRepository, UsersRepositoryV1>();
            services.AddScoped<IClientsRepository, ClientsRepositoryV1>();

            return services;
        }

        public static async Task<IServiceProvider> ApplyMigrations(this IServiceProvider provider)
        {
            using(var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await db.Database.MigrateAsync();
            }

            return provider;
        }
    }
}
