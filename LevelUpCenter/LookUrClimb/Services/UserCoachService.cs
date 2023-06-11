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

    async Task<IEnumerable<UserCoach>> IUserCoachService.ListAsync()
    {
        return await _userCoachRepository.ListAsync();
    }

    public async Task<UserCoachResponse> SaveAsync(UserCoach userCoach)
    {
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

        existingUserCoach.Username = userCoach.Username;
        existingUserCoach.TypeOfUser = userCoach.TypeOfUser;
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

    async Task<IEnumerable<UserType>> IUserTypeService.ListAsync()
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
        var existingUserType = await _userTypeRepository.FindByIdAsync(id);

        if (existingUserType == null)
            return new UserTypeResponse("User not found");

        existingUserType.Username = userType.Username;
        existingUserType.TypeOfUser = userType.TypeOfUser;

        try
        {
            _userTypeRepository.Update(existingUserType);
            await _unitOfWork.CompleteAsync();
            return new UserTypeResponse(existingUserType);
        }
        catch (Exception e)
        {
            return new UserTypeResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    async Task<UserTypeResponse> IUserTypeService.DeleteAsync(int id)
    {
        var existingUserType = await _userTypeRepository.FindByIdAsync(id);

        if (existingUserType == null)
            return new UserTypeResponse("User not found");
        
        try
        {
            _userTypeRepository.Remove(existingUserType);
            await _unitOfWork.CompleteAsync();
            return new UserTypeResponse(existingUserType);
        }
        catch (Exception e)
        {
            return new UserTypeResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }

    public async Task<UserCoachResponse> DeleteAsync(int id)
    {
        var existingUserCoach = await _userCoachRepository.FindByIdAsync(id);

        if (existingUserCoach == null)
            return new UserCoachResponse("User not found");
        
        try
        {
            _userCoachRepository.Remove(existingUserCoach);
            await _unitOfWork.CompleteAsync();
            return new UserCoachResponse(existingUserCoach);
        }
        catch (Exception e)
        {
            return new UserCoachResponse($"An error occurred while deleting the user coach: {e.Message}");
        }
    }
}