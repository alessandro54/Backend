using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface IUserCoachService
{
    Task<IEnumerable<UserCoach>> ListAsync();
    Task<UserCoachResponse> SaveAsync(UserCoach userCoach);
    Task<UserCoachResponse> UpdateAsync(int id, UserCoach userCoach);
    Task<UserCoachResponse> DeleteAsync(int id);
}