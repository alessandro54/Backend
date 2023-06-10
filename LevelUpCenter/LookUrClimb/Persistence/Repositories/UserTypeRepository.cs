using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.LookUrClimb.Persistence.Repositories;

public class UserTypeRepository : BaseRepository, IUserTypeRepository
{
    public UserTypeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserType>> ListAsync()
    {
        return await _context.UserTypes.ToListAsync();
    }

    public async Task<UserType> FindByIdAsync(int id)
    {
        return await _context.UserTypes.FindAsync(id);
    }

    public async Task AddAsync(UserType userType)
    {
        await _context.UserTypes.AddAsync(userType);
    }

    public void Update(UserType userType)
    {
        _context.UserTypes.Update(userType);
    }

    public void Remove(UserType userType)
    {
        _context.UserTypes.Remove(userType);
    }
}