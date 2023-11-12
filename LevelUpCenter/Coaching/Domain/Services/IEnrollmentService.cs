using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface IEnrollmentService
{
    Task<EnrollmentResponse> EnrollAsync(Learner learner,
        int courseId);
}
