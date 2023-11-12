using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface IEnrollmentRepository
{
    Task AddAsync(Enrollment enrollment);
}
