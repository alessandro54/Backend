using LevelUpCenter.LookUrClimb.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Repositories;

public interface IUserCoachRepository
{
    Task<IEnumerable<UserCoach>> ListAsync();
    Task<UserCoach> FindByIdAsync(int id);
    Task AddAsync(UserCoach userCoach);
    void Update(UserCoach userCoach);
    void Remove(UserCoach userCoach);
}