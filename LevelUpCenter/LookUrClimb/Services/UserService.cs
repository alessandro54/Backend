using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Home.Domain.Repositories;
using LevelUpCenter.Home.Domain.Services;
using LevelUpCenter.Home.Domain.Services.Communication;

namespace LevelUpCenter.Home.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserType>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<UserResponse> SaveAsync(UserType userType)
    {
        try
        {
            await _userRepository.AddAsync(userType);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(userType);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, UserType userType)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found");

        existingUser.TypeOfUser = userType.TypeOfUser;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found");
        
        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while deleting the user: {e.Message}");
        }
    }
}