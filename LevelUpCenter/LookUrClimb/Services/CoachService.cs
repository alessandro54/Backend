using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Repositories;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Services;

public class CoachService : ICoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public CoachService(ICoachRepository coachRepository, IUserService userService, IUnitOfWork unitOfWork)
    {
        _coachRepository = coachRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Coach?>> ListAsync()
    {
        return await _coachRepository.ListAsync();
    }

    public async Task<Coach?> GetOneAsync(int id)
    {
        return await _coachRepository.FindByIdAsync(id);
    }

    public async Task<CoachResponse> RegisterAsync(RegisterRequest model)
    {
        var user = await _userService.RegisterAsync(model);

        user.Role = UserRole.Coach;

        var coach = await this.SaveAsync(user);

        return coach;
    }

    public async Task<CoachResponse> SaveAsync(User user)
    {
        try
        {
            var coach = new Coach
            {
                Nickname = user.Username,
                User = user,
            };
            await _coachRepository.AddAsync(coach);
            await _unitOfWork.CompleteAsync();
            return new CoachResponse(coach);
        }
        catch (Exception e)
        {
            return new CoachResponse($"An error occurred while saving the coach: {e.Message}");
        }
    }
}
