using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Services;

public class CourseService : ICourseService
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
}
