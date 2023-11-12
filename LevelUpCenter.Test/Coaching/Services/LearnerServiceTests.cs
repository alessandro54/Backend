using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Coaching.Services;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using LevelUpCenter.Security.Exceptions;
using Moq;
using Xunit;

namespace LevelUpCenter.Test.Coaching.Services;

public class LearnerServiceTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<ILearnerRepository> _learnerRepositoryMock = new();

    [Fact]
    public async Task ListAsync_ShouldReturnListOfLearners()
    {
        // Arrange
        var learners = new[] { new Learner(), new Learner() };

        _learnerRepositoryMock
            .Setup(e => e.ListAsync())
            .ReturnsAsync(learners);

        var learnerService =
            new LearnerService(_learnerRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await learnerService.ListAsync();

        // Assert
        Assert.NotNull(result);

        var enumerable = result as Learner?[] ?? result.ToArray();

        Assert.IsType<Learner>(enumerable.First());
        Assert.Equal(2, enumerable.Length);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnLearnerResponse()
    {
        // Arrange
        var model = new RegisterRequest
            { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        var user = new User
        {
            Id = 1, FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", PasswordHash = "@!%!@%!@%!@"
        };

        var learner = new Learner { Id = 1, Nickname = model.Username, User = user };

        _userServiceMock.Setup(s => s.RegisterAsync(model)).ReturnsAsync(user);

        _learnerRepositoryMock.Setup(r =>
            r.AddAsync(It.IsAny<Learner>())
        ).Callback<Learner>(l => learner = l);

        var learnerService =
            new LearnerService(_learnerRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await learnerService.RegisterAsync(model);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<LearnerResponse>(result);
        Assert.Equal(learner.User, result.Resource.User);
    }

    [Fact]
    public async Task RegisterAsync_WithRepeatedUsername_ShouldThrowAppException()
    {
        // Arrange
        var request = new RegisterRequest
            { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        _learnerRepositoryMock.Setup(r =>
            r.AddAsync(It.IsAny<Learner>())
        ).Throws(new AppException("Test"));

        var learnerService =
            new LearnerService(_learnerRepositoryMock.Object, _userServiceMock.Object, _unitOfWorkMock.Object);

        // Act
        var result = await learnerService.RegisterAsync(request);

        // Assert

        Assert.NotNull(result);
        Assert.IsType<LearnerResponse>(result);
        Assert.Equal("An error occurred while saving the learner: Test", result.Message);
    }
}
