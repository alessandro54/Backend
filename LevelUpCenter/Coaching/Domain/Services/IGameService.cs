using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface IGameService
{
    Task<IEnumerable<Game>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Game>> ListAsync();
    Task<Game> GetOneAsync(int id);
    Task<GameResponse> SaveAsync(Game game);
    Task<GameResponse> UpdateAsync(int id, Game game);
    Task<GameResponse> DeleteAsync(int id);
}
