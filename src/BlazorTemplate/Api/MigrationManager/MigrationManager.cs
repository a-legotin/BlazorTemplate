using BlazorTemplate.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazorTemplate.Api.MigrationManager;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<CustomerContext>())
            {
                appContext.Database.Migrate();
            }
        }

        return host;
    }
}