using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Repositories;
using LevelUpCenter.Home.Domain.Services;
using LevelUpCenter.Home.Domain.Services.Communication;
using LevelUpCenter.Home.Resources;

namespace LevelUpCenter.Home.Services;

public class PublicationService : IPublicationService
{
    private readonly IPublicationRepository _publicationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _publicationRepository = publicationRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
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
        var existingUser = await _userRepository.FindByIdAsync(publication.UserId);
        if (existingUser == null)
            return new PublicationResponse("Invalid User");

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

        var existingUser = await _userRepository.FindByIdAsync(publication.UserId);
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