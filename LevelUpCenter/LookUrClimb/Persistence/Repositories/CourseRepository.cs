using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.LookUrClimb.Persistence.Repositories;

public class CourseRepository : BaseRepository, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Course>> ListAsync()
    {
        return await _context.Courses.ToListAsync();
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
        throw new NotImplementedException();
    }
}
