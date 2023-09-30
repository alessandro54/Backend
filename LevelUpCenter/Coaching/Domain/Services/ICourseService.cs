using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> ListAsync();
    Task<Course?> GetOneAsync(int id);
    Task<CourseResponse> SaveAsync(Course course);
}
