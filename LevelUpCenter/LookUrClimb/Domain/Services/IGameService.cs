using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface IGameService
{
    Task<IEnumerable<Game>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Game>> ListAsync();
    Task<GameResponse> SaveAsync(Game game);
    Task<GameResponse> UpdateAsync(int id, Game game);
    Task<GameResponse> DeleteAsync(int id);
}