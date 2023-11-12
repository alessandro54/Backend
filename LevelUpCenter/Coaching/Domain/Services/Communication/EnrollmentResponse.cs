using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services.Communication;

public class EnrollmentResponse : BaseResponse<Enrollment>
{
    public EnrollmentResponse(string message) : base(message)
    {
    }

    public EnrollmentResponse(Enrollment resource) : base(resource)
    {
    }
}
