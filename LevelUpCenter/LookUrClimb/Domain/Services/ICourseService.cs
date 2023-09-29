using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> ListAsync();
    Task<Course?> GetOneAsync(int id);
    Task<CourseResponse> SaveAsync(Course course);
}
