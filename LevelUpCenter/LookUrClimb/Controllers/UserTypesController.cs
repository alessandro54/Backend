using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Resources;
using LevelUpCenter.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.LookUrClimb.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserTypesController : ControllerBase
{
    private readonly IUserTypeService _userTypeService;
    private readonly IMapper _mapper;

    public UserTypesController(IUserTypeService userTypeService, IMapper mapper)
    {
        _userTypeService = userTypeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserTypeResource>> GetAllAsync()
    {
        var users = await _userTypeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<UserType>, IEnumerable<UserTypeResource>>(users);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserTypeResource typeResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserTypeResource, UserType>(typeResource);
        var result = await _userTypeService.SaveAsync(user);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserType, UserTypeResource>(result.Resource);
        return Ok(userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserTypeResource typeResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = _mapper.Map<SaveUserTypeResource, UserType>(typeResource);
        var result = await _userTypeService.UpdateAsync(id, user);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserType, UserTypeResource>(result.Resource);
        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userTypeService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var userResource = _mapper.Map<UserType, UserTypeResource>(result.Resource);
        return Ok(userResource);
    }
}