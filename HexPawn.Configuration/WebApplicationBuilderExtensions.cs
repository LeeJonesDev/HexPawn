using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexPawn.Configuration;

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
            .FirstOrDefault(conn => conn.StartsWith(env));

        if (connectionName == null)
        {
            throw new NullReferenceException($"Unable to match environment and an expected connection name from {nameof(ConnectionStringNames)} enum.");
        }

        // get the connection string from secrets (populated by railway cli, see README)
        var connectionString = webApplicationBuilder.Configuration.GetConnectionString(connectionName);

        if (connectionString == null)
        {
            throw new NullReferenceException("Missing Connection string value in user secrets. Is railway linked? Have you added your secrets?");
        }

        // set up db context
        webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString(connectionString))
                .UseSnakeCaseNamingConvention());
    }
}
