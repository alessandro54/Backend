using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Enrollment;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
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

    [HttpGet("enrolled")]
    [SwaggerOperation("As a Learner list all my enrolled courses")]
    public async Task<IActionResult> ListMyEnrollments()
    {
        try
        {
            var learner = await _learnerService.GetOneAsync(
                (User)HttpContext.Items["User"]!
            );

            if (learner == null)
                return BadRequest("You are not a learner");

            var enrollments = await _enrollmentService.ListAsync(learner!);

            var resources = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentResource>>(enrollments);

            return Ok(resources);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("enroll/{courseId:int}")]
    [SwaggerOperation("Enroll in a course")]
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
                new
                {
                    message = "Successfully enrolled in course.",
                    course = resource
                });
        }
        catch (Exception e)
        {
            return BadRequest(e is DbUpdateException ? "You are already enrolled in this course." : e.Message);
        }
    }

    [HttpDelete("leave/{courseId:int}")]
    [SwaggerOperation("Leave a course")]
    public async Task<IActionResult> Leave(int courseId)
    {
        var learner = await _learnerService.GetOneAsync(
            (User)HttpContext.Items["User"]!
        );

        if (learner == null)
            return BadRequest("You are not a learner");

        var result = await _enrollmentService.LeaveAsync(learner, courseId);

        if (!result.Success)
            return BadRequest(result.Message);

        return NoContent();
    }
}
