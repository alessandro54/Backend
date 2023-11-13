using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class EnrollmentRepository : BaseRepository, IEnrollmentRepository
{
    public EnrollmentRepository(AppDbContext context) : base(context)
    {
    }

    public Task<List<Enrollment>> ListAsync(Learner learner)
    {
        return _context.Enrollments
            .Where(e => e.LearnerId == learner.Id)
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
    }

    public void Remove(Enrollment enrollment)
    {
        _context.Enrollments.Remove(enrollment);
    }

    public Task<Enrollment?> FindByLearnerAndCourseAsync(Learner learner, Course course)
    {
        return _context.Enrollments
            .FirstOrDefaultAsync(e => e.LearnerId == learner.Id && e.CourseId == course.Id);
    }
}
