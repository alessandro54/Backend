using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Services;

public class UserCoachService : IUserCoachService
{
    private readonly IUserCoachRepository _userCoachRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserTypeRepository _userTypeRepository;

    public UserCoachService(IUserCoachRepository userCoachRepository, IUnitOfWork unitOfWork, IUserTypeRepository userTypeRepository)
    {
        _userCoachRepository = userCoachRepository;
        _unitOfWork = unitOfWork;
        _userTypeRepository = userTypeRepository;
    }

    public async Task<IEnumerable<UserCoach>> ListByUserIdAsync(int userId)
    {
        return await _userCoachRepository.FindByUserIdAsync(userId);
    }
    
    public async Task<IEnumerable<UserCoach>> ListAsync()
    {
        return await _userCoachRepository.ListAsync();
    }

    public async Task<UserCoachResponse> SaveAsync(UserCoach userCoach)
    {
        var existingUser = await _userTypeRepository.FindByIdAsync(userCoach.UserId);
        if (existingUser == null)
            return new UserCoachResponse("Invalid User");
        try
        {
            await _userCoachRepository.AddAsync(userCoach);
            await _unitOfWork.CompleteAsync();
            return new UserCoachResponse(userCoach);
        }
        catch (Exception e)
        {
            return new UserCoachResponse($"An error occurred while saving the user coach: {e.Message}");
        }
    }

    public async Task<UserCoachResponse> UpdateAsync(int id, UserCoach userCoach)
    {
        var existingUserCoach = await _userCoachRepository.FindByIdAsync(id);
        if (existingUserCoach == null)
            return new UserCoachResponse("User not found");
        
        var existingUser = await _userTypeRepository.FindByIdAsync(userCoach.UserId);
        if (existingUser == null)
            return new UserCoachResponse("Invalid user");
        
        existingUserCoach.Name = userCoach.Name;
        existingUserCoach.Last_name = userCoach.Last_name;
        existingUserCoach.Age = userCoach.Age;
        existingUserCoach.Category = userCoach.Category;
        existingUserCoach.Country = userCoach.Country;
        existingUserCoach.Image = userCoach.Image;
        existingUserCoach.Description = userCoach.Description;
        existingUserCoach.Languaje = userCoach.Languaje;
        existingUserCoach.Price = userCoach.Price;
        existingUserCoach.Rating = userCoach.Rating;
        existingUserCoach.InventoryStatus = userCoach.InventoryStatus;

        try
        {
            _userCoachRepository.Update(existingUserCoach);
            await _unitOfWork.CompleteAsync();
            return new UserCoachResponse(existingUserCoach);
        }
        catch (Exception e)
        {
            return new UserCoachResponse($"An error occurred while updating the user coach: {e.Message}");
        }
    }
    

    public async Task<UserCoachResponse> DeleteAsync(int id)
    {
        var existingUserType = await _userCoachRepository.FindByIdAsync(id);

        if (existingUserType == null)
            return new UserCoachResponse("User not found");
        
        try
        {
            _userCoachRepository.Remove(existingUserType);
            await _unitOfWork.CompleteAsync();
            return new UserCoachResponse(existingUserType);
        }
        catch (Exception e)
        {
            return new UserCoachResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }


}