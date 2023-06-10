using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.Home.Domain.Services.Communication;

public class PublicationResponse : BaseResponse<Publication>
{
    public PublicationResponse(string message) : base(message)
    {
    }

    public PublicationResponse(Publication resource) : base(resource)
    {
    }
}