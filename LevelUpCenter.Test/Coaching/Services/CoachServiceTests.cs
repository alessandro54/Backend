using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Coaching.Services;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Moq;
using Xunit;

namespace LevelUpCenter.Test.Coaching.Services;

public class CoachServiceTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ICoachRepository> _coachRepositoryMock = new();

    [Fact]
    public async Task ListAsync_ShouldReturnListOfCoaches()
    {
        // Arrange
        var coaches = new[] { new Coach(), new Coach() };

        _coachRepositoryMock
            .Setup(r => r.ListAsync())
                .ReturnsAsync(coaches);

        var coachService = new CoachService(_coachRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await coachService.ListAsync();

        // Assert
        Assert.NotNull(result);

        var enumerable = result as Coach?[] ?? result.ToArray();

        Assert.IsType<Coach>(enumerable.First());
        Assert.Equal(2, enumerable.Length);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnCoach()
    {
        // Arrange
        var coach = new Coach{ Nickname = "test" };

        _coachRepositoryMock
            .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(coach);

        var coachService = new CoachService(_coachRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await coachService.GetOneAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Coach>(result);
        Assert.Equal(coach.Nickname, result?.Nickname);
    }

    [Fact]
    public async Task RegisterAsync_WithValidModel_ShouldReturnCoachResponse()
    {
        // Arrange
        var model = new RegisterRequest
            { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        var user = new User
        { Id = 1, FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", PasswordHash = "@!%!@%!@%!@" };

        var coach = new Coach { Id = 1, Nickname = "sanity", User = user };

        _userServiceMock.Setup(repo => repo.RegisterAsync(model)).ReturnsAsync(user);

        _coachRepositoryMock.Setup(
            repo => repo.AddAsync(
                It.IsAny<Coach>())
        ).Callback<Coach>(c => coach = c);

        var coachService = new CoachService(_coachRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await coachService.RegisterAsync(model);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CoachResponse>(result);
        Assert.True(result.Success);
        Assert.Equal(coach, result.Resource);
    }
}
