using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class CoachResponse : BaseResponse<Coach>
{
    public CoachResponse(string message) : base(message)
    {
    }

    public CoachResponse(Coach resource) : base(resource)
    {
    }
}
