using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Services.Communication;

namespace LevelUpCenter.Home.Domain.Services;

public interface IPublicationService
{
    //CRUD
    Task<IEnumerable<Publication>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Publication>> ListAsync();
    Task<PublicationResponse> SaveAsync(Publication publication);
    Task<PublicationResponse> UpdateAsync(int id, Publication publication);
    Task<PublicationResponse> DeleteAsync(int id);
}