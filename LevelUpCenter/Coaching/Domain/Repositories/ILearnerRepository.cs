using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface ILearnerRepository
{
    Task<IEnumerable<Learner?>> ListAsync();
    Task<Learner?> FindByAsync(int id);
    Task<Learner?> FindByAsync(User user);
    Task AddAsync(Learner learner);
    void Update(Learner learner);
    void Remove(Learner learner);
}
