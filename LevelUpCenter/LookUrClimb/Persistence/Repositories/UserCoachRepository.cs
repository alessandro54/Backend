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
        return await _context.UserCoaches.ToListAsync();
    }

    public async Task<UserCoach> FindByIdAsync(int id)
    {
        return await _context.UserCoaches.FindAsync(id);
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