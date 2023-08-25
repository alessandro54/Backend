using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Repositories;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Domain.Services.Communication;

namespace LevelUpCenter.LookUrClimb.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserTypeRepository _userTypeRepository;

    public GameService(IGameRepository gameRepository, IUnitOfWork unitOfWork, IUserTypeRepository userTypeRepository)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
        _userTypeRepository = userTypeRepository;
    }

    public async Task<IEnumerable<Game>> ListByUserIdAsync(int userId)
    {
        return await _gameRepository.FindByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Game>> ListAsync()
    {
        return await _gameRepository.ListAsync();
    }

    public async Task<GameResponse> SaveAsync(Game game)
    {
        try
        {
            await _gameRepository.AddAsync(game);
            await _unitOfWork.CompleteAsync();
            return new GameResponse(game);
        }
        catch (Exception e)
        {
            return new GameResponse($"An error occurred while saving the publication: {e.Message}");
        }
    }

    public async Task<GameResponse> UpdateAsync(int id, Game game)
    {
        var existingGame = await _gameRepository.FindByIdAsync(id);
        if (existingGame == null)
            return new GameResponse("Game not found.");

        existingGame.Name = game.Name;
        existingGame.ImageUrl = game.ImageUrl;
        existingGame.Description = game.Description;

        try
        {
            _gameRepository.Update(existingGame);
            await _unitOfWork.CompleteAsync();
            return new GameResponse(existingGame);
        }
        catch (Exception e)
        {
            return new GameResponse($"An error occurred while updating the video-game: {e.Message}");
        }
    }

    public async Task<GameResponse> DeleteAsync(int id)
    {
        var existingGame = await _gameRepository.FindByIdAsync(id);
        if (existingGame == null)
            return new GameResponse("Publication not found.");

        try
        {
            _gameRepository.Remove(existingGame);
            await _unitOfWork.CompleteAsync();
            return new GameResponse(existingGame);
        }
        catch (Exception e)
        {
            return new GameResponse($"An error occurred while deleting the publication: {e.Message}");
        }
    }
}
