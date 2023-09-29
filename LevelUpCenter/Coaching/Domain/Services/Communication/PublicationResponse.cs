using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services.Communication;

public class PublicationResponse : BaseResponse<Publication>
{
    public PublicationResponse(string message) : base(message)
    {
    }

    public PublicationResponse(Publication resource) : base(resource)
    {
    }
}