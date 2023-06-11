using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Resources;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.LookUrClimb.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserCoachesController : ControllerBase
{
    private readonly IUserCoachService _userCoachService;
    private readonly IMapper _mapper;

    public UserCoachesController(IMapper mapper, IUserCoachService userCoachService)
    {
        _mapper = mapper;
        _userCoachService = userCoachService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserCoachResource>> GetAllAsync()
    {
        var users = await _userCoachService.ListAsync();
        var resources = _mapper.Map<IEnumerable<UserCoach>, IEnumerable<UserCoachResource>>(users);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserCoachResource coachResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserCoachResource, UserCoach>(coachResource);
        var result = await _userCoachService.SaveAsync(user);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserCoach, UserCoachResource>(result.Resource);
        return Ok(userResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserCoachResource coachResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserCoachResource, UserCoach>(coachResource);
        var result = await _userCoachService.UpdateAsync(id, user);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserCoach, UserCoachResource>(result.Resource);
        return Ok(userResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userCoachService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserCoach, UserCoachResource>(result.Resource);
        return Ok(userResource);
    }
}