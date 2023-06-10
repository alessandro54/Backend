using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Home.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserType>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserType> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(UserType userType)
    {
        await _context.Users.AddAsync(userType);
    }

    public void Update(UserType userType)
    {
        _context.Users.Update(userType);
    }

    public void Remove(UserType userType)
    {
        _context.Users.Remove(userType);
    }
}