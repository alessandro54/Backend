using LevelUpCenter.Home.Domain.Models;

namespace LevelUpCenter.Home.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserType>> ListAsync();
    Task<UserType> FindByIdAsync(int id);
    Task AddAsync(UserType userType);
    void Update(UserType userType);
    void Remove(UserType userType);
}