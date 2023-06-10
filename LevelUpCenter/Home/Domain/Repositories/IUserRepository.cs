using LevelUpCenter.Home.Domain.Models;

namespace LevelUpCenter.Home.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
}