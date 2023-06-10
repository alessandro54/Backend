using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Services.Communication;

namespace LevelUpCenter.Home.Domain.Services;

public interface IUserService
{
    //CRUD
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
}