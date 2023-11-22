using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface IEnrollmentRepository
{
    Task<List<Enrollment>> ListAsync(Learner learner);
    Task AddAsync(Enrollment enrollment);
    void Remove(Enrollment enrollment);
    Task<Enrollment?> FindByLearnerAndCourseAsync(Learner learner, Course course);
}
