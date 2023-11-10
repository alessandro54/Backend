using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface ILearnerService
{
    Task<IEnumerable<Learner?>> ListAsync();
    Task<Learner?> GetOneAsync(int id);
    Task<LearnerResponse> RegisterAsync(RegisterRequest request);
    Task<LearnerResponse> SaveAsync(User user);
}
