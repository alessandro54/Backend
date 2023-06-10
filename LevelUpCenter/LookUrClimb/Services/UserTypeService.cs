using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Services;

public class UserTypeService : IUserTypeService
{
    private readonly IUserTypeRepository _userTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserTypeService(IUserTypeRepository userTypeRepository, IUnitOfWork unitOfWork)
    {
        _userTypeRepository = userTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserType>> ListAsync()
    {
        return await _userTypeRepository.ListAsync();
    }

    public async Task<UserTypeResponse> SaveAsync(UserType userType)
    {
        try
        {
            await _userTypeRepository.AddAsync(userType);
            await _unitOfWork.CompleteAsync();
            return new UserTypeResponse(userType);
        }
        catch (Exception e)
        {
            return new UserTypeResponse($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserTypeResponse> UpdateAsync(int id, UserType userType)
    {
        var existingUser = await _userTypeRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserTypeResponse("User not found");

        existingUser.TypeOfUser = userType.TypeOfUser;

        try
        {
            _userTypeRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserTypeResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserTypeResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserTypeResponse> DeleteAsync(int id)
    {
        var existingUser = await _userTypeRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserTypeResponse("User not found");
        
        try
        {
            _userTypeRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserTypeResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserTypeResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}