using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services.Communication;

public class LearnerResponse : BaseResponse<Learner>
{
    public LearnerResponse(string message) : base(message)
    {
    }

    public LearnerResponse(Learner resource) : base(resource)
    {
    }
}
