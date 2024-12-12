using Microsoft.AspNetCore.Builder;

namespace Order.Infrastructure.Data.Extentions;

public static class DatabaseExtentions
{
    /// <summary>
    /// This is a service which provide auto migration for develepment enviroment
    /// With that way update-database will run automaticly.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        context.Database.MigrateAsync().GetAwaiter().GetResult(); // this will wait till migration operation complete.
    }
}
