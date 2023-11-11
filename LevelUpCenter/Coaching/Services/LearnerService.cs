using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;

namespace LevelUpCenter.Coaching.Services;

public class LearnerService : ILearnerService
{
    private readonly ILearnerRepository _learnerRepository;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public LearnerService(ILearnerRepository learnerRepository, IUserService userService, IUnitOfWork unitOfWork)
    {
        _learnerRepository = learnerRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Learner?>> ListAsync()
    {
        return await _learnerRepository.ListAsync();
    }

    public async Task<Learner?> GetOneAsync(int id)
    {
        return await _learnerRepository.FindByIdAsync(id);
    }

    public async Task<LearnerResponse> RegisterAsync(RegisterRequest request)
    {
        var user = await _userService.RegisterAsync(request);

        var coach = new Learner
        {
            User = user,
            Nickname = request.Username
        };

        return await SaveAsync(coach);
    }

    public async Task<LearnerResponse> SaveAsync(Learner learner)
    {
        try
        {
            await _learnerRepository.AddAsync(learner);
            await _unitOfWork.CompleteAsync();
            return new LearnerResponse(learner);
        }
        catch (Exception e)
        {
            return new LearnerResponse($"An error occurred while saving the learner: {e.Message}");
        }
    }
}
