using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class GameResponse : BaseResponse<Game>
{
    public GameResponse(string message) : base(message)
    {
    }

    public GameResponse(Game resource) : base(resource)
    {
    }
}