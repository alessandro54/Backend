using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class PublicationResponse : BaseResponse<Publication>
{
    public PublicationResponse(string message) : base(message)
    {
    }

    public PublicationResponse(Publication resource) : base(resource)
    {
    }
}