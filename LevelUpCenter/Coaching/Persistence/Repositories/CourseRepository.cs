using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class CourseRepository : BaseRepository, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Course>> ListAsync()
    {
        return await _context
            .Courses
            .Include(c => c.Coach)
            .Include(c => c.Game)
            .ToListAsync();
    }

    public async Task<Course?> FindByIdAsync(int id)
    {
        return await _context.Courses
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public void Update(Course course)
    {
        throw new NotImplementedException();
    }

    public void Remove(Course course)
    {
        _context.Courses.Remove(course);
    }
}
