using System.Linq.Expressions;
using HexPawn.Data.Repositories;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models.Entities;
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
            DeletedAt = new DateTime(2024, 3, 1),
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
            DeletedAt = null,
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
            DeletedAt = null,
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

        #region Where

        repository
            .Setup(r => r.Where(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(IQueryable<Player>
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var where = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Where(filter);

                return where;
            });

        #endregion

        #region First

        repository
            .Setup(r => r.First(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var first = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .First(filter);

                return first;
            });

        repository
            .Setup(r => r.FirstOrDefault(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player?
            (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var firstOrDefault = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .FirstOrDefault(filter);

                return firstOrDefault;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.FirstAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player
                (Expression<Func<Player, bool>> filter,
                    bool? includeDeleted = false,
                    CancellationToken cancellationToken = default) =>
            {
                var first =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .First(filter);

                return first;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.FirstOrDefaultAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player?
            (Expression<Func<Player, bool>> filter,
                bool? includeDeleted = false,
                CancellationToken cancellationToken = default) =>
            {
                var firstOrDefault =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .FirstOrDefault(filter);

                return firstOrDefault;
            });

        #endregion

        #region Single

        repository
            .Setup(r => r.Single(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var single = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Single(filter);

                return single;
            });

        repository
            .Setup(r => r.SingleOrDefault(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player?
            (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var singleOrDefault = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .SingleOrDefault(filter);

                return singleOrDefault;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.SingleAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player
                (Expression<Func<Player, bool>> filter,
                    bool? includeDeleted = false,
                    CancellationToken cancellationToken = default) =>
            {
                var single =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Single(filter);

                return single;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player?
            (Expression<Func<Player, bool>> filter,
                bool? includeDeleted = false,
                CancellationToken cancellationToken = default) =>
            {
                var singleOrDefault =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .SingleOrDefault(filter);

                return singleOrDefault;
            });

        #endregion

        #region Last

        repository
            .Setup(r => r.Last(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var last = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Last(filter);

                return last;
            });

        repository
            .Setup(r => r.LastOrDefault(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(Player?
            (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var lastOrDefault = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .LastOrDefault(filter);

                return lastOrDefault;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.LastAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player
                (Expression<Func<Player, bool>> filter,
                    bool? includeDeleted = false,
                    CancellationToken cancellationToken = default) =>
            {
                var last =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Last(filter);

                return last;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.LastOrDefaultAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(Player?
            (Expression<Func<Player, bool>> filter,
                bool? includeDeleted = false,
                CancellationToken cancellationToken = default) =>
            {
                var lastOrDefault =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .LastOrDefault(filter);

                return lastOrDefault;
            });

        #endregion

        #region Any

        repository
            .Setup(r => r.Any(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(bool
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var any = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Any(filter);

                return any;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.AnyAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(bool
            (Expression<Func<Player, bool>> filter,
                bool? includeDeleted = false,
                CancellationToken cancellationToken = default) =>
            {
                var any =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .Any(filter);

                return any;
            });

        #endregion

        #region All

        repository
            .Setup(r => r.All(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>()))
            .Returns(bool
                (Expression<Func<Player, bool>> filter, bool? includeDeleted = false) =>
            {
                var all = Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .All(filter);

                return all;
            });

        //TODO: write cancellation token test & scaffold
        repository
            .Setup(r => r.AllAsync(
                It.IsAny<Expression<Func<Player, bool>>>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>()))!
            .ReturnsAsync(bool
            (Expression<Func<Player, bool>> filter,
                bool? includeDeleted = false,
                CancellationToken cancellationToken = default) =>
            {
                var all =  Players
                    .AsQueryable()
                    .Where(RepositoryExtensions.FilterSoftDeletes<Player>(includeDeleted))
                    .All(filter);

                return all;
            });

        #endregion

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
