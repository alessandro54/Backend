using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface ILearnerRepository
{
    Task<IEnumerable<Learner?>> ListAsync();
    Task<Learner?> FindByIdAsync(int id);
    Task AddAsync(Learner learner);
    void Update(Learner learner);
    void Remove(Learner learner);
}
