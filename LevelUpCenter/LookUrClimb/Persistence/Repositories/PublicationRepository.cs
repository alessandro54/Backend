using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.LookUrClimb.Persistence.Repositories;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    public PublicationRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _context.Publications.Include(p => p.UserType).ToListAsync();
    }

    public async Task<Publication> FindByIdAsync(int tutorialId)
    {
        return await _context.Publications
            .Include(p => p.UserType)
            .FirstOrDefaultAsync(p => p.Id == tutorialId);
    }

    public async Task<IEnumerable<Publication>> FindByUserIdAsync(int userId)
    {
        return await _context.Publications
            .Where(p => p.UserId == userId)
            .Include(p => p.UserType)
            .ToListAsync();
    }

    public async Task<Publication> FindByTitleAsync(string title)
    {
        return await _context.Publications
            .Include(p => p.UserType)
            .FirstOrDefaultAsync(p => p.Title == title);
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