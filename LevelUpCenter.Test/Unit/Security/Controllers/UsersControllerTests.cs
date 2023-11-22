using System.Security.Claims;
using AutoMapper;
using LevelUpCenter.Security.Controllers;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using LevelUpCenter.Security.Exceptions;
using LevelUpCenter.Security.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpecFlow.Internal.Json;
using Xunit;
using Xunit.Abstractions;

namespace LevelUpCenter.Test.Unit.Security.Controllers;

public class UsersControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Mock<IUserService> _userService = new();
    private readonly Mock<IMapper> _mapper = new();

    public UsersControllerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task Authenticate_ValidRequest_ReturnsToken()
    {
        // Arrange
        var request = new AuthenticateRequest { Username = "test", Password = "123456" };

        _userService.Setup(s =>
                s.Authenticate(request))
                    .ReturnsAsync(new AuthenticateResponse { Token = "fake-jwt-token" });

        // Act
        var controller = new UsersController(_userService.Object, _mapper.Object);
        var result = await controller.Authenticate(request);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
        Assert.Equal(
            "fake-jwt-token",
            ((AuthenticateResponse)((OkObjectResult)result).Value!)?.Token
        );
    }

    [Fact]
    public async Task Authenticate_InvalidRequest_ReturnMessage()
    {
        // Arrange
        var request = new AuthenticateRequest { Username = "test", Password = "test" };

        _userService.Setup(s =>
                s.Authenticate(request))
                    .ThrowsAsync(new AppException(""));

        // Act
        var controller = new UsersController(_userService.Object, _mapper.Object);
        var result = await controller.Authenticate(request);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal(
            "{ message = Wrong credentials }",
            ((UnauthorizedObjectResult)result).Value?.ToString()
        );
    }

    [Fact]
    public async Task GetProfile_ReturnsProfile()
    {
        // Arrange
        var user = new User { Id = 1, Username = "testuser" };

        _mapper.Setup(m =>
            m.Map<User, UserResource>(It.IsAny<User>()))
                .Returns(new UserResource());

        var httpContext = new DefaultHttpContext
        {
            User = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "testuser") }))
        };

        var controller = new UsersController(_userService.Object, _mapper.Object)
        {
            ControllerContext = new ControllerContext { HttpContext = httpContext }
        };

        // Act
        var result = await controller.GetProfile();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }
}
