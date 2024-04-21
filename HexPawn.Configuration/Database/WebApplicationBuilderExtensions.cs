using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexPawn.Configuration.Database;

public static class WebApplicationBuilderExtensions
{
    public static void AddDbContext(this WebApplicationBuilder webApplicationBuilder)
    {
        // get the current running environment
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (env == null)
        {
            throw new NullReferenceException("Unable to discover Environment from current launchSettings.");
        }

        // get the connection name that matches the environment
        var connectionName = Enum
            .GetNames<ConnectionStringNames>()
            .FirstOrDefault(conn => conn.StartsWith(env))
            ?.ToString();

        if (connectionName == null)
        {
            throw new NullReferenceException($"Unable to match environment and an expected connection name from {nameof(ConnectionStringNames)} enum.");
        }

        // get the connection string by the connection name from either AppSettings or UserSecrets
        var connectionString = webApplicationBuilder.Configuration.GetConnectionString(connectionName);

        if (connectionString == null)
        {
            throw new NullReferenceException("Missing Connection string value in ConnectionStrings. add it in either AppSettings or in UserSecrets.");
        }

        // set up db context with the connection using postgres db
        webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString(connectionString))
                .UseSnakeCaseNamingConvention());
    }
}
