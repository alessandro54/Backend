using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface IUserCoachService : IUserTypeService
{
    new Task<IEnumerable<UserCoach>> ListAsync();
    Task<UserCoachResponse> SaveAsync(UserCoach userCoach);
    Task<UserCoachResponse> UpdateAsync(int id, UserCoach userCoach);
    new Task<UserCoachResponse> DeleteAsync(int id);
}