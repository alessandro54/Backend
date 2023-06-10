using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class UserTypeResponse : BaseResponse<UserType>
{
    public UserTypeResponse(string message) : base(message)
    {
    }

    public UserTypeResponse(UserType resource) : base(resource)
    {
    }
}