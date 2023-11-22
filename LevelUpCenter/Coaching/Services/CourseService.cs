using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Coaching.Resources.Course;

namespace LevelUpCenter.Coaching.Services;

public class
    CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Course>> ListAsync()
    {
        return await _courseRepository.ListAsync();
    }

    public async Task<Course?> GetOneAsync(int id)
    {
        return await _courseRepository.FindByIdAsync(id);
    }

    public async Task<CourseResponse> SaveAsync(Course course)
    {
        try
        {
            await _courseRepository.AddAsync(course);
            await _unitOfWork.CompleteAsync();
            return new CourseResponse(course);
        }
        catch (Exception e)
        {
            return new CourseResponse($"An error occurred while saving the publication: {e.Message}");
        }
    }

    public async Task<CourseResponse> DeleteAsync(int id)
    {
        var existing = await _courseRepository.FindByIdAsync(id);
        if (existing == null)
            return new CourseResponse("Course not found.");

        try
        {
            _courseRepository.Remove(existing);
            await _unitOfWork.CompleteAsync();
            return new CourseResponse(existing);
        }
        catch (Exception e)
        {
            return new CourseResponse($"An error occurred while deleting the course: {e.Message}");
        }
    }
}
