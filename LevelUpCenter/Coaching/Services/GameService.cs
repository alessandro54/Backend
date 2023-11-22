using System.Diagnostics;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Repositories;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Domain.Services.Communication;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace LevelUpCenter.Coaching.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GameService(IGameRepository gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Game>> ListByUserIdAsync(int userId)
    {
        return await _gameRepository.FindByUserIdAsync(userId);
    }

    public async Task<IEnumerable<Game>> ListAsync()
    {
        return await _gameRepository.ListAsync();
    }

    public async Task<Game> GetOneAsync(int id)
    {
        return await _gameRepository.FindByIdAsync(id);
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

        existingGame.Name = game.Name ?? existingGame.Name;
        existingGame.Description = game.Description ?? existingGame.Description;
        existingGame.IconUrl = game.IconUrl ?? existingGame.IconUrl;
        existingGame.BannerUrl = game.BannerUrl ?? existingGame.BannerUrl;
        existingGame.SplashUrl = game.SplashUrl ?? existingGame.SplashUrl;
        existingGame.Rating = game.Rating != 0 ? game.Rating : existingGame.Rating;

        existingGame.UpdatedAt = DateTime.Now;

        try
        {
            _gameRepository.Update(existingGame);
            await _unitOfWork.CompleteAsync();
            return new GameResponse(existingGame);
        }
        catch (Exception e)
        {
            if (e is not DbUpdateException)
                return new GameResponse($"An error occurred while updating the video-game: {e.Message}");
            return e.InnerException is MySqlException { Number: 1062 } ? new GameResponse("The game name already exists.") : new GameResponse($"An error occurred while updating the video-game: {e.Message}");
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
