using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface IEnrollmentService
{
    Task<List<Enrollment>> ListAsync(Learner learner);
    Task<EnrollmentResponse> EnrollAsync(Learner learner, int courseId);
    Task<EnrollmentResponse> LeaveAsync(Learner learner, int courseId);
}
