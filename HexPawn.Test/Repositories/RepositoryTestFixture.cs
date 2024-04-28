using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models.Entities;

namespace HexPawn.Test.Repositories;

public class RepositoryTestFixture
{
    public IRepository<Player> PlayerRepository;

    public RepositoryTestFixture()
    {
        PlayerRepository = MockPlayerRepository.GetMockRepository().Object;
    }
}
