using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Domain.Services;

public interface IPublicationService
{
    //CRUD
    Task<IEnumerable<Publication>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Publication>> ListAsync();
    Task<PublicationResponse> SaveAsync(Publication publication);
    Task<PublicationResponse> UpdateAsync(int id, Publication publication);
    Task<PublicationResponse> DeleteAsync(int id);
}