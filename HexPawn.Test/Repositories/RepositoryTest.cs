using HexPawn.Data.Repositories;
using HexPawn.Models;
using HexPawn.Models.Entities;
using JetBrains.Annotations;


namespace HexPawn.Test.Repositories;

[TestSubject(typeof(Repository<BaseEntity>))]
public class RepositoryTest(RepositoryTestFixture fixture) : IClassFixture<RepositoryTestFixture>
{
    [Fact]
    public void GetNoParamsTest()
    {
        var all = fixture.PlayerRepository.Get();
        Assert.NotNull(all);
        Assert.Equal(3, all.Count());
    }

    [Fact]
    public void GetNonMatchingFilterTest()
    {
        var badFilter = fixture.PlayerRepository.Get(filter: r => r.PlayerName == "ABCDEFG");
        Assert.Empty(badFilter);
    }

    [Fact]
    public void GetMatchingFilterTest()
    {
        var filtered = fixture.PlayerRepository.Get(filter: r => r.PlayerName == "Test 1");
        var players = filtered.ToList();
        
        Assert.NotNull(players);
        Assert.Single(players);
        Assert.Equivalent(MockPlayerRepository.Players.First(x => x.PlayerName == "Test 1"), players.First());
    }

    [Fact]
    public void GetOrderedTest()
    {
        var ordered = fixture.PlayerRepository.Get(orderBy: x => x.OrderByDescending(p => p.BirthDate));
        var players = ordered.ToList();
        
        Assert.NotNull(players);
        Assert.Equal(3, players.Count());
        Assert.Equal(MockPlayerRepository.Players.Max(p => p.BirthDate), players.First().BirthDate);
        Assert.Equal(MockPlayerRepository.Players.Min(p => p.BirthDate), players.Last().BirthDate);
    }

    /// <summary>
    /// Where Clause for Repository Queryable on the dbset respecting soft deletes
    /// </summary>
    [Theory]
    [InlineData("Test 2" )]
    [InlineData("Test 1" , true)]
    public void WhereTest(string playerName, bool? includeDeleted = false)
    {
        IQueryable<Player>? queryable;
        if (!includeDeleted.HasValue)
        {
            queryable = fixture.PlayerRepository
                .Where(x => x.PlayerName == playerName);
        }
        else
        {
            queryable = fixture.PlayerRepository
                .Where(x => x.PlayerName == playerName, includeDeleted);
        }
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
    [Theory]
    [InlineData("Test 1" )]
    public void WhereDeletedTest(string playerName)
    {
        IQueryable<Player>? queryable = fixture.PlayerRepository
            .Where(x => x.PlayerName == playerName);
        
        var players = queryable?.ToList();

        Assert.NotNull(players);
        Assert.Empty(players);
    }
    
    
}
