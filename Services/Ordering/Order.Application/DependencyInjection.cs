using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BuildingBlock.Behaviors;
using BuildingBlockMessaging.MassTransit;
using BuildingBlocks.Behaviors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(ValidationBehavior<,>));
                config.AddBehavior(typeof(LoggingBehavior<,>));
            });

            //services.AddFeatureManagement();
            //services.AddMessageBroker(config, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
