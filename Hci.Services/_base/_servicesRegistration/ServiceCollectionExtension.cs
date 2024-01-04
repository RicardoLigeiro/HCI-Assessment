using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hci.Services;

public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Extension method to do the DI declaration
    /// </summary>
    /// <param name="services">Services collection</param>
    /// <param name="connectionString">Connection String</param>
    /// <returns></returns>
    public static IServiceCollection AddHciPersistenceCollection(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString),
            ServiceLifetime.Transient);
        services.AddTransient<IVisitRepository, VisitRepository>();
        return services;
    }
}