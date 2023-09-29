using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Domain.Services;

public interface IPublicationService
{
    //CRUD
    Task<IEnumerable<Publication>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Publication>> ListAsync();
    Task<PublicationResponse> SaveAsync(Publication publication);
    Task<PublicationResponse> UpdateAsync(int id, Publication publication);
    Task<PublicationResponse> DeleteAsync(int id);
}