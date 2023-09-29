using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services.Communication;
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
        // Arrange
        var model = new RegisterRequest { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        var user = new User
        {
            Id = 1, FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", PasswordHash = "@!%!@%!@%!@"
        };

        var coach = new Coach { Id = 1, Nickname = "sanity", User = user };

        var userRepositoryMock = new Mock<IUserService>();
        userRepositoryMock.Setup(repo => repo.RegisterAsync(model)).ReturnsAsync(user);

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var coachRepositoryMock = new Mock<ICoachRepository>();

        coachRepositoryMock.Setup(
            repo => repo.AddAsync(
                It.IsAny<Coach>())
        ).Callback<Coach>(c => coach = c);

        var coachService = new CoachService(coachRepositoryMock.Object, userRepositoryMock.Object, unitOfWorkMock.Object);

        // Act
        var result = await coachService.RegisterAsync(model);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CoachResponse>(result);
        Assert.True(result.Success);
        Assert.Equal(coach, result.Resource);
    }
}
