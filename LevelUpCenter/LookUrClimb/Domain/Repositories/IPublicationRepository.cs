using LevelUpCenter.LookUrClimb.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Repositories;

public interface IPublicationRepository
{
    Task<IEnumerable<Publication>> ListAsync();
    Task<Publication> FindByIdAsync(int tutorialId);
    Task<IEnumerable<Publication>> FindByUserIdAsync(int userId);
    Task<Publication> FindByTitleAsync(string title);
    Task AddAsync(Publication publication);
    void Update(Publication publication);
    void Remove(Publication publication);
}