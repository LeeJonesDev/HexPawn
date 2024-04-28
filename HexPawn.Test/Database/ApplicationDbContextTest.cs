using HexPawn.Configuration.Database;
using HexPawn.Models.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Test.Database;

[TestSubject(typeof(ApplicationDbContext))]
public class ApplicationDbContextTest
{

    /// <summary>
    /// tests an in memory dbContext can be created using the ApplicationDbContext
    /// </summary>
    [Fact]
    public void CanCreateContextTest()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApplicationDbContext(builder.Options);

        Assert.NotNull(builder);
        Assert.NotNull(context);
        Assert.True(builder.IsConfigured);
    }

    /// <summary>
    /// Proves that can perform FirstOrDefault, Add, Include and in background this runs the
    /// model builder to set up the BaseEntities automatically to make this possible
    /// </summary>
    [Fact]
    public async Task CanQueryContextTest()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new ApplicationDbContext(builder.Options);

        var email = $"{Guid.NewGuid().ToString()}@test.com";
        var testEntity = new Player
            {
                UniqueId = Guid.NewGuid().ToString(),
                CreatedAt = default,
                UpdatedOn = default,
                PlayerName =Guid.NewGuid().ToString(),
                EmailAddress = email,
                FistName = "Test",
                LastName = "Test",
                BirthDate = new DateOnly(1979, 4, 16),
                Characters =  [new Character
                            {
                                UniqueId =  Guid.NewGuid().ToString(),
                                CreatedAt = default,
                                UpdatedOn = default,
                                Name = "Test"
                            }]
            };

            await context.AddAsync(testEntity);
            await context.SaveChangesAsync();

            var dbPlayer = await context.Players
                .Include(player => player.Characters)
                .FirstOrDefaultAsync();

            Assert.NotNull(dbPlayer);
            Assert.NotNull(dbPlayer.Characters);

            Assert.NotEmpty(dbPlayer.Characters);
    }
}
