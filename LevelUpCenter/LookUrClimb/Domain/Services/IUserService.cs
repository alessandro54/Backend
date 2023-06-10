using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Services.Communication;

namespace LevelUpCenter.Home.Domain.Services;

public interface IUserService
{
    //CRUD
    Task<IEnumerable<UserType>> ListAsync();
    Task<UserResponse> SaveAsync(UserType userType);
    Task<UserResponse> UpdateAsync(int id, UserType userType);
    Task<UserResponse> DeleteAsync(int id);
}