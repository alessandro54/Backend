using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Services;

public class CoachService : ICoachService
{
    private readonly ICoachRepository _coachRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CoachService(ICoachRepository coachRepository, IUnitOfWork unitOfWork)
    {
        _coachRepository = coachRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Coach>> ListAsync()
    {
        return await _coachRepository.ListAsync();
    }

    public Task<Coach> GetOneAsync(int id)
    {
        //hrow new NotImplementedException();
    }

    public async Task<CoachResponse> SaveAsync(User user)
    {
        try
        {
            var coach = new Coach
            {
                Nickname = user.Username,
                User = user
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
