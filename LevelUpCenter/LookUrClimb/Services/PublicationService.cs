using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Services;

public class PublicationService : IPublicationService
{
    private readonly IPublicationRepository _publicationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserTypeRepository _userTypeRepository;

    public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IUserTypeRepository userTypeRepository)
    {
        _publicationRepository = publicationRepository;
        _unitOfWork = unitOfWork;
        _userTypeRepository = userTypeRepository;
    }

    public async Task<IEnumerable<Publication>> ListByUserIdAsync(int userId)
    {
        return await _publicationRepository.FindByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _publicationRepository.ListAsync();
    }

    public async Task<PublicationResponse> SaveAsync(Publication publication)
    {
        var existingUser = await _userTypeRepository.FindByIdAsync(publication.UserId);
        if (existingUser == null)
            return new PublicationResponse("Invalid User");
        
        var existingTitle = await _publicationRepository.FindByTitleAsync(publication.Title);
        if (existingTitle != null)
            return new PublicationResponse("Title already exist.");

        try
        {
            await _publicationRepository.AddAsync(publication);
            await _unitOfWork.CompleteAsync();
            return new PublicationResponse(publication);
        }
        catch (Exception e)
        {
            return new PublicationResponse($"An error occurred while saving the publication: {e.Message}");
        }
    }

    public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
    {
        var existingPublication = await _publicationRepository.FindByIdAsync(id);
        if (existingPublication == null)
            return new PublicationResponse("Publication not found.");

        var existingUser = await _userTypeRepository.FindByIdAsync(publication.UserId);
        if (existingUser == null)
            return new PublicationResponse("Invalid user");

        existingPublication.UrlImage = publication.UrlImage;
        existingPublication.Description = publication.Description;

        try
        {
            _publicationRepository.Update(existingPublication);
            await _unitOfWork.CompleteAsync();
            return new PublicationResponse(existingPublication);
        }
        catch (Exception e)
        {
            return new PublicationResponse($"An error occurred while updating the publication: {e.Message}");
        }
    }

    public async Task<PublicationResponse> DeleteAsync(int id)
    {
        var existingPublication = await _publicationRepository.FindByIdAsync(id);
        if (existingPublication == null)
            return new PublicationResponse("Publication not found.");

        try
        {
            _publicationRepository.Remove(existingPublication);
            await _unitOfWork.CompleteAsync();
            return new PublicationResponse(existingPublication);
        }
        catch (Exception e)
        {
            return new PublicationResponse($"An error occurred while deleting the publication: {e.Message}");
        }
    }
}