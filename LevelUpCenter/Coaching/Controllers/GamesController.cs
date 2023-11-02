using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources;
using LevelUpCenter.Coaching.Resources.Game;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.Coaching.Controllers;

[AuthorizeAdmin]
[ApiController]
[Route("/api/v1/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IMapper _mapper;

    public GamesController(IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<GameResource>> GetAllAsync()
    {
        var games = await _gameService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResource>>(games);
        return resources;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{id:int}")]
    public async Task<GameResource> GetOneAsync(int id)
    {
        var game = await _gameService.GetOneAsync(id);
        var resource = _mapper.Map<Game, GameResource>(game);
        return resource;
    }

    [AuthorizeAdmin]
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

    [AuthorizeAdmin]
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

    [AuthorizeAdmin]
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
