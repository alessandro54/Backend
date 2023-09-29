using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services.Communication;

public class CourseResponse : BaseResponse<Course>
{
    public CourseResponse(string message) : base(message)
    {
    }

    public CourseResponse(Course resource) : base(resource)
    {
    }
}
