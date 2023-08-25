using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Resources;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.LookUrClimb.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class GameController : ControllerBase
{
     private readonly IGameService _gameService;
    private readonly IMapper _mapper;

    public GameController(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GameResource>> GetAllAsync()
    {
        var games = await _gameService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResource>>(games);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveGameResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var game = _mapper.Map<SaveGameResource, Game>(resource);

        var result = await _gameService.SaveAsync(game);
        if (!result.Success)
            return BadRequest(result.Message);

        var gameResource = _mapper.Map<Game, GameResource>(result.Resource);

        return Ok(gameResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveGameResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var game = _mapper.Map<SaveGameResource, Game>(resource);

        var result = await _gameService.UpdateAsync(id, game);
        if (!result.Success)
            return BadRequest(result.Message);

        var gameResource = _mapper.Map<Game, GameResource>(result.Resource);

        return Ok(gameResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _gameService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var publicationResource = _mapper.Map<Game, GameResource>(result.Resource);

        return Ok(publicationResource);
    }
}
