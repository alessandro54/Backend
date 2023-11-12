using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Course;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete courses")]
public class CoursesController: ControllerBase

{

    private readonly ICourseService _courseService;
    private readonly ICoachService _coachService;
    private readonly IMapper _mapper;

    public CoursesController(ICourseService courseService, ICoachService coachService, IMapper mapper)
    {
        _courseService = courseService;
        _coachService = coachService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    [SwaggerOperation("Get all courses")]
    public async Task<IEnumerable<CourseResource>> GetAllCourses()
    {
        var courses = await _courseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);

        return resources;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOneCourse(int id)
    {
        var course = await _courseService.GetOneAsync(id);

        if (course is not { Published: true })
            return NotFound();

        var resource = _mapper.Map<Course, CourseResource>(course);

        return Ok(resource);
    }

    [AuthorizeCoach]
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] SaveCourseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var coach = await _coachService.GetOneAsync(user: (User) HttpContext.Items["User"]!);

        var course = _mapper.Map<SaveCourseResource, Course>(resource);

        course.CoachId = coach!.Id;

        var result= await _courseService.SaveAsync(course);

        var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);

        return Created("Successfully created", courseResource);
    }

    [AuthorizeCoach]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var user = (User) HttpContext.Items["User"]!;

        if (user.Role == UserRole.Coach)
        {
            var coach = _coachService.GetOneAsync(user);

            if (coach.Result != null && !coach.Result.IsCourseOwner(id))
                return Unauthorized(new { Unauthorized = "You must own the course" });
        }
        var result = await _courseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);

        return Ok(courseResource);
    }
}
