using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using MySql.Data.MySqlClient;

namespace LevelUpCenter.Coaching.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseService _courseService;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        ICourseService courseService,
        IUnitOfWork unitOfWork
    )
    {
        _enrollmentRepository = enrollmentRepository;
        _courseService = courseService;
        _unitOfWork = unitOfWork;
    }

    public async Task<EnrollmentResponse> EnrollAsync(Learner learner, int courseId)
    {
        var course = await _courseService.GetOneAsync(courseId);

        var enrollment = new Enrollment { Learner = learner, Course = course! };

        await _enrollmentRepository.AddAsync(enrollment);
        await _unitOfWork.CompleteAsync();

        return new EnrollmentResponse(enrollment);
    }
}
