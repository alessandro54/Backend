using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;

namespace LevelUpCenter.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}