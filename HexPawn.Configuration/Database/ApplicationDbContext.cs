using HexPawn.Models;
using HexPawn.Models.Entities;
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
                    t.IsSubclassOf(typeof(BaseEntity)) &&
                    !t.IsAbstract);

            foreach (var baseEntityType in types)
            {
                modelBuilder
                    // register the entity
                    .Entity(baseEntityType)
                    // Set unique constraints
                    .HasIndex(nameof(BaseEntity.UniqueId))
                    .IsUnique();
            }
        }

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Character> Characters { get; set; }
}
