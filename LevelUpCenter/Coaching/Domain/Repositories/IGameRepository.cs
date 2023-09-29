using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<Game>> ListAsync();
    Task<Game> FindByIdAsync(int gameId);
    Task<IEnumerable<Game>> FindByUserIdAsync(int userId);
    Task AddAsync(Game game);
    void Update(Game game);
    void Remove(Game game);
}
