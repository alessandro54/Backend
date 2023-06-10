using LevelUpCenter.Shared.Persistence.Contexts;

namespace LevelUpCenter.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    } 
}