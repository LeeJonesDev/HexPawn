using HexPawn.Configuration.Database;
using HexPawn.Data.Repositories;
using HexPawn.Data.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build db context and set up entity framework
builder.AddDbContext();



// var assemblies = AppDomain.CurrentDomain.GetAssemblies();
// foreach (var assembly in assemblies)
// {
//     var repositories = assembly
//         .GetTypes()
//         .Where(t =>
//             t.GetInterface(nameof(IBaseRepository<T>)) != null &&
//             !t.IsInterface);
//     foreach (var repository in repositories)
//     {
//         builder.Services.AddTransient<IBaseRepository, repository> ();
//     }
// }


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
