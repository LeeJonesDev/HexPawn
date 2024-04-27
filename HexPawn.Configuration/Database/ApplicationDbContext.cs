using System.Reflection;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Configuration.Database;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");

        // register the entity implementing a base entity class
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            // get the implementations
            var types = assembly
                .GetTypes()
                .Where(t =>
                    t.IsSubclassOf(typeof(TBaseEntity)) &&
                    !t.IsAbstract);

            foreach (var baseEntityType in types)
            {
                modelBuilder
                    // register the entity
                    .Entity(baseEntityType)
                    // Set unique constraints
                    .HasIndex(nameof(TBaseEntity.UniqueId))
                    .IsUnique();
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
