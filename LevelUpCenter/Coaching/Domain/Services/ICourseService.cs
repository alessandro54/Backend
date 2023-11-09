using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Coaching.Resources.Course;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> ListAsync();
    Task<Course?> GetOneAsync(int id);
    Task<CourseResponse> SaveAsync(Course course);
    Task<CourseResponse> DeleteAsync(int id);
}
