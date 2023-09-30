using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class PublicationRepository : BaseRepository, IPublicationRepository
{
    public PublicationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _context.Publications.ToListAsync();
    }

    public async Task<Publication> FindByIdAsync(int tutorialId)
    {
        return await _context.Publications
            .FirstOrDefaultAsync(p => p.Id == tutorialId);
    }

    public async Task<IEnumerable<Publication>> FindByUserIdAsync(int userId)
    {
        return await _context.Publications
            .Where(p => p.Course.CoachId == userId)
            .ToListAsync();
    }

    public async Task<Publication> FindByTitleAsync(string title)
    {
        return await _context.Publications
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
