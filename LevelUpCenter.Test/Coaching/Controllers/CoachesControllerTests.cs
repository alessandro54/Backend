using AutoMapper;
using LevelUpCenter.Coaching.Controllers;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LevelUpCenter.Test.Coaching.Controllers;

public class CoachesControllerTests
{
    private readonly Coach _coach = new()
    {
        Id = 1,
        Nickname = "sanity44",
        User = new User
        {
            Id = 1,
            FirstName = "Alessandro",
            LastName = "Chumpitaz",
            Username = "sanity",
            PasswordHash = "C#GizeObEiUzQYh@7c",
        }
    };

    [Fact]
    public async Task PostAsync_ValidRequest_ReturnsCreatedResult()
    {
        // Arrange
        var mockCoachesService = new Mock<ICoachService>();
        var mockUserService = new Mock<IUserService>();
        var mockMapper = new Mock<IMapper>();

        var controller = new CoachesController(
            mockCoachesService.Object,
            mockUserService.Object,
            mockMapper.Object
        );

        var request = new RegisterRequest
            { FirstName = "Alessandro", LastName = "Chumpitaz", Username = "sanity", Password = "123456" };

        var expectedResult = new CoachResponse(_coach);

        var expectedCoachResource = new SaveCoachResource
        {
            Nickname = "sanity",
            User = _coach.User
        };

        mockCoachesService
            .Setup(service => service.RegisterAsync(request))
                .ReturnsAsync(expectedResult);

        mockMapper
            .Setup(mapper => mapper.Map<Coach, SaveCoachResource>(expectedResult.Resource))
                .Returns(expectedCoachResource);

        // Act
        var result = await controller.PostAsync(request);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal("Successfully created", createdResult.Location);

        var coachResource = Assert.IsType<SaveCoachResource>(createdResult.Value);
        Assert.Same(expectedCoachResource, coachResource);
    }

    [Fact]
    public async Task GetOneAsync_CoachExists_ReturnsCoachResource()
    {
        // Arrange
        var mockCoachService = new Mock<ICoachService>();
        var mockMapper = new Mock<IMapper>();

        var controller = new CoachesController(
            mockCoachService.Object,
            Mock.Of<IUserService>(),
            mockMapper.Object
        );

        var expectedCoach = _coach;
        var expectedCoachResource = new CoachResource { Nickname = "sanity44" };

        mockCoachService
            .Setup(service => service.GetOneAsync(_coach.Id))
                .ReturnsAsync(expectedCoach);

        mockMapper
            .Setup(mapper => mapper.Map<Coach, CoachResource>(expectedCoach))
                .Returns(expectedCoachResource);

        // Act
        var result = await controller.GetOneAsync(_coach.Id);

        // Assert

        var coachResource = Assert.IsType<CoachResource>(result);
        Assert.Same(expectedCoachResource, coachResource);
    }

    [Fact]
    public async Task GetOneAsync_CoachDoesNotExist_ReturnsNull()
    {
        // Arrange
        var mockCoachService = new Mock<ICoachService>();
        var mockMapper = new Mock<IMapper>();

        var controller = new CoachesController(mockCoachService.Object, Mock.Of<IUserService>(), mockMapper.Object);

        mockCoachService
            .Setup(service => service.GetOneAsync(_coach.Id))
            .ReturnsAsync((Coach?)null);

        // Act
        var result = await controller.GetOneAsync(1);

        // Assert
        Assert.Null(result);
    }
}
