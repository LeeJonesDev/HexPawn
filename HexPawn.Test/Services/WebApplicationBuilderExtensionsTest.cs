using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using HexPawn.Configuration.Services;

namespace HexPawn.Test.Services;

[TestSubject(typeof(WebApplicationBuilderExtensions))]
public class ServicesWebApplicationBuilderExtensionsTest
{
    /// <summary>
    /// Integration test for Services setup extension method
    /// </summary>
    [Fact]
    public void ServicesSetupTest()
    {
        var builder = WebApplication.CreateBuilder();

        Assert.NotNull(builder);

        WebApplicationBuilderExtensions.AddServices(builder);

        var app = builder.Build();
    }
}
