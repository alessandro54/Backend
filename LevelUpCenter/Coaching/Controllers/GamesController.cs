using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Game;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation("Get all games")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of all available Games.")]
    public async Task<IEnumerable<GameResource>> GetAllAsync()
    {
        var games = await _gameService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Game>, IEnumerable<GameResource>>(games);
        return resources;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{id:int}")]
    [SwaggerOperation("Get a game by id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a Game with the specified id.")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Game with the specified id was not found.")]
    public async Task<GameResource> GetOneAsync(int id)
    {
        var game = await _gameService.GetOneAsync(id);
        var resource = _mapper.Map<Game, GameResource>(game);
        return resource;
    }

    [HttpPost]
    [SwaggerOperation("[Admin only] Create a new game")]
    [SwaggerResponse(StatusCodes.Status200OK, "Creates a new Game.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Unable to create the Game due to validation error.")]
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

    [HttpPatch("{id:int}")]
    [HttpPut("{id:int}")]
    [SwaggerOperation("[Admin only] Update an existing game")]
    [SwaggerResponse(StatusCodes.Status200OK, "Updates an existing Game.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Unable to update the Game due to validation error.")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateGameResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var game = _mapper.Map<UpdateGameResource, Game>(resource);

        var result = await _gameService.UpdateAsync(id, game);
        if (!result.Success)
            return BadRequest(result.Message);

        var gameResource = _mapper.Map<Game, GameResource>(result.Resource);

        return Ok(gameResource);
    }

    [AuthorizeAdmin]
    [HttpDelete("{id:int}")]
    [SwaggerOperation("[Admin only] Delete an existing game")]
    [SwaggerResponse(StatusCodes.Status200OK, "Deletes an existing Game.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Unable to delete the Game due to validation error.")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _gameService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var publicationResource = _mapper.Map<Game, GameResource>(result.Resource);

        return Ok(publicationResource);
    }
}
