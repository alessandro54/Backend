using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Services;

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
