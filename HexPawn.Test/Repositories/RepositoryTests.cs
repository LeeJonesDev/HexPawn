using HexPawn.Data.Repositories;
using HexPawn.Models;
using JetBrains.Annotations;

namespace HexPawn.Test.Repositories;

[TestSubject(typeof(Repository<BaseEntity>))]
public class RepositoryTests(RepositoryTestFixture fixture) : IClassFixture<RepositoryTestFixture>
{
    #region Where

    /// <summary>
    /// Where Clause for Repository Queryable on the dbset respecting soft deletes
    /// </summary>
    /// <param name="playerName"></param>
    /// <param name="includeDeleted"></param>
    [Theory]
    [InlineData("Test 2" )]
    [InlineData("Test 1" , true)]
    public void WhereNotDeletedTest(string playerName, bool? includeDeleted = false)
    {
        var queryable = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .Where(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .Where(x => x.PlayerName == playerName, includeDeleted);
        var players = queryable?.ToList();

        Assert.NotNull(players);
        Assert.NotEmpty(players);
        Assert.Single(players);
        Assert.Equivalent(MockPlayerRepository.Players
            .First(x => x.PlayerName == playerName),
            players.First());
    }



    /// <summary>
    /// Where Clause for Repository Queryable on the dbset excluding soft deletes
    /// </summary>
    /// <param name="playerName"></param>
    [Theory]
    [InlineData("Test 1" )]
    public void WhereDeletedTest(string playerName)
    {
        var queryable = fixture.PlayerRepository
            .Where(x => x.PlayerName == playerName);

        var players = queryable?.ToList();

        Assert.NotNull(players);
        Assert.Empty(players);
    }

    #endregion

    #region First

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public void FirstTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .First(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .First(x => x.PlayerName == playerName, includeDeleted);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .First(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public void FirstOrDefaultTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .FirstOrDefault(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .FirstOrDefault(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                            .FirstOrDefault(x => x.PlayerName == playerName),
                        firstPlayer);
        }
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public async void FirstAsyncTest(string playerName, bool? includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                // ReSharper disable once MethodSupportsCancellation testing without passing in
                .FirstAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .FirstAsync(x => x.PlayerName == playerName,
                    includeDeleted,
                    cancellationToken);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .First(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public async void FirstOrDefaultAsyncTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                .FirstOrDefaultAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .FirstOrDefaultAsync(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                    .FirstOrDefault(x => x.PlayerName == playerName),
                firstPlayer);
        }
    }

    #endregion

    #region Single

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public void SingleTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .Single(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .Single(x => x.PlayerName == playerName, includeDeleted);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .Single(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public void SingleOrDefaultTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .SingleOrDefault(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .SingleOrDefault(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                            .SingleOrDefault(x => x.PlayerName == playerName),
                        firstPlayer);
        }
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public async void SingleAsyncTest(string playerName, bool? includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                // ReSharper disable once MethodSupportsCancellation testing without passing in
                .SingleAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .SingleAsync(x => x.PlayerName == playerName,
                    includeDeleted,
                    cancellationToken);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .Single(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public async void SingleOrDefaultAsyncTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                .SingleOrDefaultAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .SingleOrDefaultAsync(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                    .SingleOrDefault(x => x.PlayerName == playerName),
                firstPlayer);
        }
    }

    #endregion


    #region Last

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public void LastTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .Last(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .Last(x => x.PlayerName == playerName, includeDeleted);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .Last(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public void LastOrDefaultTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? fixture.PlayerRepository
                .LastOrDefault(x => x.PlayerName == playerName)
            : fixture.PlayerRepository
                .LastOrDefault(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                            .LastOrDefault(x => x.PlayerName == playerName),
                        firstPlayer);
        }
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    public async void LastAsyncTest(string playerName, bool? includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                // ReSharper disable once MethodSupportsCancellation testing without passing in
                .LastAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .LastAsync(x => x.PlayerName == playerName,
                    includeDeleted,
                    cancellationToken);

        Assert.NotNull(firstPlayer);
        Assert.Equivalent(MockPlayerRepository.Players
                .Last(x => x.PlayerName == playerName),
            firstPlayer);
    }

    [Theory]
    [InlineData("Test 2")]
    [InlineData("Test 1", true)]
    [InlineData("Samuel", true)]
    public async void LastOrDefaultAsyncTest(string playerName, bool? includeDeleted = false)
    {
        var firstPlayer = !includeDeleted.HasValue
            ? await fixture.PlayerRepository
                .LastOrDefaultAsync(x => x.PlayerName == playerName)
            : await fixture.PlayerRepository
                .LastOrDefaultAsync(x => x.PlayerName == playerName, includeDeleted);

        if (firstPlayer == null)
        {
            Assert.Null(firstPlayer);
        }
        else
        {
            Assert.NotNull(firstPlayer);
            Assert.Equivalent(MockPlayerRepository.Players
                    .LastOrDefault(x => x.PlayerName == playerName),
                firstPlayer);
        }
    }

    #endregion










}
