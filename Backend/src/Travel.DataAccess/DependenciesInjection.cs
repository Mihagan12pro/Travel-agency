using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
