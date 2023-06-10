using LevelUpCenter.LookUrClimb.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Repositories;

public interface IUserTypeRepository
{
    Task<IEnumerable<UserType>> ListAsync();
    Task<UserType> FindByIdAsync(int id);
    Task AddAsync(UserType userType);
    void Update(UserType userType);
    void Remove(UserType userType);
}