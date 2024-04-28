using HexPawn.Configuration.Database;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;

namespace HexPawn.Test.Database;

[TestSubject(typeof(WebApplicationBuilderExtensions))]
public class DatabaseWebApplicationBuilderExtensionsTest
{
    /// <summary>
    /// Integration test for DB context setup extension method
    /// </summary>
    [Fact]
    public void DBSetuptest()
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == null)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        }
        if (Environment.GetEnvironmentVariable("ConnectionStrings:Development") == null)
        {
            Environment.SetEnvironmentVariable("ConnectionStrings:Development", "Server=localhost;Port=5432;Database=localDb;Userid=postgres;Password=admin;");
        }

        var builder = WebApplication.CreateBuilder();

        Assert.NotNull(builder);

        WebApplicationBuilderExtensions.AddDbContext(builder);

        var app = builder.Build();
    }
}
