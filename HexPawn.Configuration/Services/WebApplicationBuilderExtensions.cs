using HexPawn.Data.Repositories;
using HexPawn.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace HexPawn.Configuration.Services;

public static class WebApplicationBuilderExtensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        //Add generic interface and implementation of repository
        builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));


    }

}
