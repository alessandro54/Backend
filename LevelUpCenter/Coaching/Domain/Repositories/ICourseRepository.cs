using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Domain.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> ListAsync();
    Task<Course?> FindByIdAsync(int id);
    Task AddAsync(Course course);
    void Update(Course course);
    void Remove(Course course);
}
