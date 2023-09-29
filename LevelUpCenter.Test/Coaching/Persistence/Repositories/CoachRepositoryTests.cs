using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Persistence.Repositories;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Shared.Persistence.Contexts;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Test.Coaching.Persistence.Repositories;

public class CoachRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly CoachRepository _coachRepository;

    public CoachRepositoryTests()
    {
        // Arrange: Set up the in-memory database and repository for each test.
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new AppDbContext(options);
        _coachRepository = new CoachRepository(_context);

        _context.Coaches.Add(new Coach { Id = 1, Nickname = "test", User = new User { Id = 1, FirstName = "John", LastName = "Doe", Username = "testtest", PasswordHash = "@!$!%215!@%@!%!@ads" } });
        _context.Coaches.Add(new Coach { Id = 2, Nickname = "test2", User = new User { Id = 2, FirstName = "John", LastName = "Doe", Username = "testtest2", PasswordHash = "@!$!%215!@%@!%!@ads" } });
        _context.SaveChangesAsync();
    }

    [Fact]
    public async Task ListAsync_ShouldReturnListOfCoaches()
    {
        // Act
        var coaches = await _coachRepository.ListAsync();

        // Assert
        Assert.Equal(2, coaches.Count());
    }

    [Fact]
    public async Task FindByIdAsync_ShouldReturnCoach()
    {
        // Act
        var coach = await _coachRepository.FindByIdAsync(1);

        // Assert
        Assert.NotNull(coach);
        Assert.Equal("test", coach.Nickname);
    }

    public void Dispose()
    {
        // Cleanup: Dispose of the context after all tests are done.
        _context.Dispose();
    }
}
