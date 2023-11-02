using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface ICoachService
{
    Task<IEnumerable<Coach?>> ListAsync();
    Task<Coach?> GetOneAsync(int id);
    Task<CoachResponse> RegisterAsync(RegisterRequest request);
    Task<CoachResponse> SaveAsync(User user);
}
