using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface ICoachRepository
{
    Task<IEnumerable<Coach?>> ListAsync();
    Task<Coach?> FindByIdAsync(int id);
    Task<Coach> FindByUserAsync(User user);
    Task AddAsync(Coach coach);
    void Update(Coach coach);
    void Remove(Coach coach);
}
