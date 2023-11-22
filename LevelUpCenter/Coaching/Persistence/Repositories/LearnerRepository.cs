using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Shared.Persistence.Contexts;
using LevelUpCenter.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Coaching.Persistence.Repositories;

public class LearnerRepository : BaseRepository, ILearnerRepository
{
    public LearnerRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<IEnumerable<Learner?>> ListAsync()
    {
        return await _context.Learners.ToListAsync();
    }
    public async Task<Learner?> FindByAsync(int id)
    {
        return await _context.Learners.Include(l => l.User)
            .FirstOrDefaultAsync(p => p!.Id == id);
    }

    public async Task<Learner?> FindByAsync(User user)
    {
        return await _context.Learners.Include(l => l.User)
            .FirstOrDefaultAsync(p => p!.User == user);
    }
    public async Task AddAsync(Learner learner)
    {
        await _context.Learners.AddAsync(learner);
    }
    public void Update(Learner learner)
    {
        _context.Learners.Update(learner);
    }
    public void Remove(Learner learner)
    {
        _context.Learners.Remove(learner);
    }
}
