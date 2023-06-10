using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface IUserTypeService
{
    //CRUD
    Task<IEnumerable<UserType>> ListAsync();
    Task<UserTypeResponse> SaveAsync(UserType userType);
    Task<UserTypeResponse> UpdateAsync(int id, UserType userType);
    Task<UserTypeResponse> DeleteAsync(int id);
}