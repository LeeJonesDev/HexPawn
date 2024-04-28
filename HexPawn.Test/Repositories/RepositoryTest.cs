using HexPawn.Data.Repositories;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using HexPawn.Models.Entities;
using JetBrains.Annotations;
using Moq;

namespace HexPawn.Test.Repositories;

[TestSubject(typeof(Repository<BaseEntity>))]
public class RepositoryTest
{

    [SkippableFact]
    public void GetTest()
    {
        var mockRepo = MockPlayerRepository.GetMockRepository().Object;

        var x = mockRepo.Get();

        mockRepo.Get(filter: r => r.PlayerName == "Test 1");

        mockRepo.Get(orderBy: x => x.OrderByDescending(p => p.BirthDate));

        mockRepo.Get(includeProperties: "Character");

    }

    [SkippableFact]
    public void METHOD()
    {

    }
}
