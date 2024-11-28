using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIfrasturctureService(this IServiceCollection services , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DataBase");

        return services;
    }

}
