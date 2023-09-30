using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class GameRepository : BaseRepository, IGameRepository
{
    public GameRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Game>> ListAsync()
    {
        return await _context.Games.ToListAsync();
    }

    public async Task<Game> FindByIdAsync(int gameId)
    {
        return await _context.Games
            .FirstOrDefaultAsync(p => p.Id == gameId);
    }

    public async Task<IEnumerable<Game>> FindByUserIdAsync(int userId)
    {
        return await _context.Games
            .ToListAsync();
    }

    public async Task AddAsync(Game game)
    {
        await _context.Games.AddAsync(game);
    }

    public void Update(Game game)
    {
        _context.Games.Update(game);
    }

    public void Remove(Game game)
    {
        _context.Games.Remove(game);
    }
}
