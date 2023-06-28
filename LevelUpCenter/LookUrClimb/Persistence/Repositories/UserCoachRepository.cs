using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.LookUrClimb.Persistence.Repositories;

public class UserCoachRepository : BaseRepository, IUserCoachRepository
{
    public UserCoachRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserCoach>> ListAsync()
    {
        return await _context.UserCoaches.Include(p => p.UserType).ToListAsync();
    }

    public async Task<UserCoach> FindByIdAsync(int id)
    {
        return await _context.UserCoaches
            .Include(p => p.UserType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<UserCoach>> FindByUserIdAsync(int userId)
    {
        return await _context.UserCoaches
            .Where(p => p.UserId == userId)
            .Include(p => p.UserType)
            .ToListAsync();
    }

    public async Task AddAsync(UserCoach userCoach)
    {
        await _context.UserCoaches.AddAsync(userCoach);
    }

    public void Update(UserCoach userCoach)
    {
        _context.UserCoaches.Update(userCoach);
    }

    public void Remove(UserCoach userCoach)
    {
        _context.UserCoaches.Remove(userCoach);
    }
}