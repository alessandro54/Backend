using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.Home.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}