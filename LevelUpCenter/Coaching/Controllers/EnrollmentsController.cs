using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Enrollment;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/courses")]
public class EnrollmentsController : ControllerBase
{
    private readonly ILearnerService _learnerService;
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;

    public EnrollmentsController(
        IEnrollmentService enrollmentService,
        ILearnerService learnerService,
        IMapper mapper
    )
    {
        _enrollmentService = enrollmentService;
        _learnerService = learnerService;
        _mapper = mapper;
    }

    [HttpPost("{courseId:int}/enroll")]
    public async Task<IActionResult> Enroll(int courseId)
    {
        try
        {
            var learner = await _learnerService.GetOneAsync(
                (User)HttpContext.Items["User"]!
            );

            var result = await _enrollmentService.EnrollAsync(
                learner!,
                courseId
            );

            if (!result.Success)
                return BadRequest(result.Message);

            var resource = _mapper.Map<Enrollment, EnrollmentResource>(result.Resource);

            return Created(
                $"/api/v1/courses/{courseId}/enroll",
                resource);
        }
        catch (Exception e)
        {
            return BadRequest(e is DbUpdateException ? "You are already enrolled in this course." : e.Message);
        }
    }
}
