using AutoMapper;
using LevelUpCenter.Coaching.Controllers;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Course;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LevelUpCenter.Test.Unit.Coaching.Controllers;

public class CoursesControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<ICourseService> _courseService;
    private readonly Mock<ICoachService> _coachService;
    private readonly Mock<IMapper> _mapper;


    public CoursesControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _courseService = new Mock<ICourseService>();
        _coachService = new Mock<ICoachService>();
        _mapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task GetAllCourses_ReturnsCourses()
    {
        var resources = new[]
        {
            new CourseResource(),
            new CourseResource(),
            new CourseResource()
        };
        // Arrange
        var controller = new CoursesController(
            _courseService.Object,
            _coachService.Object,
            _mapper.Object
        );

        _mapper.Setup(
            m =>
                m.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(
                    It.IsAny<IEnumerable<Course>>()
                )
        ).Returns(resources);

        // Act
        var result = await controller.GetAllCourses();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Count());

        _mapper.Verify(
            m =>
                m.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(
                    It.IsAny<IEnumerable<Course>>()
                ),
            Times.Once
        );
    }
}
