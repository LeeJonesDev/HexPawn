using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;

namespace HexPawn.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    
}
