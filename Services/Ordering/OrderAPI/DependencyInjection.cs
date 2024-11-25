using System.Net.WebSockets;

namespace OrderAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services)
    {

        //services.AddCarter();
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        
        return app;

    }
}
