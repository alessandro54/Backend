using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;
using Org.BouncyCastle.Utilities.Encoders;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class UserCoachResponse : BaseResponse<UserCoach>
{
    public UserCoachResponse(string message) : base(message)
    {
    }

    public UserCoachResponse(UserCoach resource) : base(resource)
    {
    }
}