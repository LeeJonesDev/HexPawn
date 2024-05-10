using HexPawn.Data.Repositories;
using HexPawn.Models;
using HexPawn.Models.Entities;
using JetBrains.Annotations;


namespace HexPawn.Test.Repositories;

[TestSubject(typeof(Repository<BaseEntity>))]
public class RepositoryTest : IClassFixture<RepositoryTestFixture>
{
    private RepositoryTestFixture _fixture;
    public RepositoryTest(RepositoryTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetNoParamsTest()
    {
        var all = _fixture.PlayerRepository.Get();
        Assert.NotNull(all);
        Assert.Equal(all.Count(), 3);
    }

    [Fact]
    public void GetNonMatchingFilterTest()
    {
        var badFilter = _fixture.PlayerRepository.Get(filter: r => r.PlayerName == "ABCDEFG");
        Assert.Equal(badFilter.Count(), 0);
    }

    [Fact]
    public void GetMatchingFilterTest()
    {
        var filtered = _fixture.PlayerRepository.Get(filter: r => r.PlayerName == "Test 1");
        Assert.NotNull(filtered);
        Assert.Equal(filtered.Count(), 1);
        Assert.Equivalent(filtered.First(), MockPlayerRepository.Players.First(x => x.PlayerName == "Test 1"));
    }

    [Fact]
    public void GetOrderedTest()
    {
        var ordered = _fixture.PlayerRepository.Get(orderBy: x => x.OrderByDescending(p => p.BirthDate));
        Assert.NotNull(ordered);
        Assert.Equal(ordered.Count(), 3);
        Assert.Equal(ordered.First().BirthDate, MockPlayerRepository.Players.Max(p => p.BirthDate));
        Assert.Equal(ordered.Last().BirthDate, MockPlayerRepository.Players.Min(p => p.BirthDate));
    }

    //TODO: update if includes are improved
    [Fact]
    public void GetIncludesTest()
    {
        var includes = _fixture.PlayerRepository.Get(includeProperties: "Character");
        Assert.NotNull(includes);
        Assert.NotNull(includes.First().Characters);
        Assert.NotNull(includes.First().Characters.First().UniqueId);
    }

    [SkippableFact]
    public void METHOD()
    {

    }

    [Fact]
    public void AlternateGet()
    {
        var all = _fixture.PlayerRepository.Get2();
        Assert.NotNull(all);
        Assert.Equal(all.Count(), 3);
    }
}
