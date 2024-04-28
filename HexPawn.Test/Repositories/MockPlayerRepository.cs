using System.Linq.Expressions;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HexPawn.Test.Repositories;

internal class MockPlayerRepository
{
    public static readonly List<Player> Players =
    [
        new Player
        {
            Id = 1,
            UniqueId = "4c341274-eb32-4305-af2b-c2f2389a4b4d",
            CreatedAt = new DateTime(2022, 12, 11),
            UpdatedOn = new DateTime(2022, 12, 11),
            PlayerName = "Test 1",
            EmailAddress = "testEmail1@test.com",
            FistName = null,
            LastName = null,
            BirthDate = default,
            Characters =
            [
                new Character
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    CreatedAt = default,
                    UpdatedOn = default,
                    Name = "Test 1 C"
                }
            ]
        },

        new Player
        {
            Id = 2,
            UniqueId = "8be73b85-2685-454e-b288-a43b495ceab2",
            CreatedAt = new DateTime(2023, 3, 11),
            UpdatedOn = new DateTime(2023, 3, 11),
            PlayerName = "Test 2",
            EmailAddress = "testEmail2@test.com",
            FistName = null,
            LastName = null,
            BirthDate = default,
            Characters =
            [
                new Character
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    CreatedAt = default,
                    UpdatedOn = default,
                    Name = "Test 2 C"
                }
            ]
        },

        new Player
        {
            Id = 3,
            UniqueId = "6a1b6e1a-be8d-4540-b51d-5fed1bdff7da",
            CreatedAt = new DateTime(2024, 3, 1),
            UpdatedOn = new DateTime(2024, 3, 5),
            PlayerName = "Test 3",
            EmailAddress = "testEmail3@test.com",
            FistName = null,
            LastName = null,
            BirthDate = default,
            Characters =
            [
                new Character
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    CreatedAt = default,
                    UpdatedOn = default,
                    Name = "Test 2 C"
                }
            ]
        }
    ];

    public static Mock<IRepository<Player>> GetMockRepository()
    {
        var repository = new Mock<IRepository<Player>>();

        char[] separator = [','];


        repository
            .Setup(r => r.Get(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<Func<IQueryable<Player>, IOrderedQueryable<Player>>>(),
                It.IsAny<string>()))
            .Returns(IEnumerable<Player> (
                Expression<Func<Player, bool>>? filter = null,
                Func<IQueryable<Player>, IOrderedQueryable<Player>>? orderBy = null,
                string? includeProperties = "") =>
            {
                var query = Players;
                var queryable = query.AsQueryable();
                queryable = filter != null ? queryable.Where(filter) : queryable;
                queryable = includeProperties?.Split(separator, StringSplitOptions.RemoveEmptyEntries).Aggregate(queryable, (current, s) => current.Include(s));
                    return (orderBy != null && queryable != null
                               ? orderBy(queryable).ToList()
                               : queryable?.ToList())
                           ?? [];
            });

        repository
            .Setup(r => r.GetByIDAsync(It.IsAny<int>()).Result)
            .Returns((int id) => Players.FirstOrDefault(p => p.Id == id));

        repository
            .Setup(r => r.GetByUniqueIdAsync(It.IsNotNull<string>()).Result)
            .Returns((string id) => Players.FirstOrDefault(p => p.UniqueId == id));

        repository
            .Setup(r => r.InsertAsync(It.IsAny<Player>()))
            .Callback(() => { });

        repository
            .Setup(r => r.InsertRangeAsync(It.IsAny<IEnumerable<Player>>()))
            .Callback(() => { });

        repository
            .Setup(r => r.Delete(It.IsAny<int>()))
            .Callback(() => { });
        repository
            .Setup(r => r.Delete(It.IsAny<string>()))
            .Callback(() => { });

        repository
            .Setup(r => r.Delete(It.IsAny<Player>()))
            .Callback(() => { });

        repository
            .Setup(r => r.DeleteRange(It.IsAny<IEnumerable<Player>>()))
            .Callback(() => { });

        repository
            .Setup(r => r.Update(It.IsAny<Player>()))
            .Callback(() => { });

        repository
            .Setup(r => r.UpdateRange(It.IsAny<IEnumerable<Player>>()))
            .Callback(() => { });

        repository
            .Setup(r => r.Attach(It.IsAny<Player>()))
            .Callback(() => { });

        repository
            .Setup(r => r.AttachRange(It.IsAny<IEnumerable<Player>>()))
            .Callback(() => { });

        repository
            .Setup(r => r.SaveChangesAsync().Result)
            .Callback(() => { });

        return repository;
    }
}
