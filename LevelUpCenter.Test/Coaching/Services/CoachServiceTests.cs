using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Services;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LevelUpCenter.Test.Coaching.Services;

public class CoachServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CoachServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task RegisterAsync_WithValidModel_ShouldReturnCoachResponse()
    {
        var userServiceMock = new Mock<IUserService>();
        var coachRepositoryMock = new Mock<ICoachRepository>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var coachServiceMock = new CoachService(
            coachRepositoryMock.Object,
            userServiceMock.Object,
            unitOfWorkMock.Object
        );

        // Arrange
        var registerRequest = new RegisterRequest
            { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        var user = new User
        {
            Id = 1, FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", PasswordHash = "@!%!@%!@%!@"
        };

        userServiceMock.Setup(
            s => s.RegisterAsync(registerRequest, UserRole.Coach)
        ).ReturnsAsync(user);

        coachRepositoryMock.Setup(
            s => s.AddAsync(
                It.IsAny<Coach>()
            )
        ).Returns(Task.CompletedTask);

        unitOfWorkMock.Setup(
            s => s.CompleteAsync()
        ).Returns(Task.CompletedTask);

        // Act
        var result = await coachServiceMock.RegisterAsync(registerRequest);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal("Alessandro", result.Resource.User.FirstName);
        Assert.Equal("sanity", result.Resource.Nickname);

        userServiceMock.Verify(s => s.RegisterAsync(
            registerRequest, UserRole.Coach
        ), Times.Once);

        coachRepositoryMock.Verify(repository => repository.AddAsync(It.IsAny<Coach>()), Times.Once);

        unitOfWorkMock.Verify(unitOfWork => unitOfWork.CompleteAsync(), Times.Once);
    }
}
