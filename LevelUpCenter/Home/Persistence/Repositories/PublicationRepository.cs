using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Home.Persistence.Repositories;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    public PublicationRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _context.Publications.Include(p => p.User).ToListAsync();
    }

    public async Task<Publication> FindByIdAsync(int tutorialId)
    {
        return await _context.Publications
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == tutorialId);
    }

    public async Task<IEnumerable<Publication>> FindByUserIdAsync(int userId)
    {
        return await _context.Publications
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Publication publication)
    {
        await _context.Publications.AddAsync(publication);
    }

    public void Update(Publication publication)
    {
        _context.Publications.Update(publication);
    }

    public void Remove(Publication publication)
    {
        _context.Publications.Remove(publication);
    }
}