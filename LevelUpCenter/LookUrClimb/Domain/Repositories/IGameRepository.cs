using LevelUpCenter.LookUrClimb.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<Game>> ListAsync();
    Task<Game> FindByIdAsync(int gameId);
    Task<IEnumerable<Game>> FindByUserIdAsync(int userId);
    Task AddAsync(Game game);
    void Update(Game game);
    void Remove(Game game);
}