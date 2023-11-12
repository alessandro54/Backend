using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
{
    public EnrollmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
    }
}
