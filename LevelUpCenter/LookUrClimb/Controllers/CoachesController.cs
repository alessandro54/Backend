using AutoMapper;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.LookUrClimb.Domain.Services;
using LevelUpCenter.LookUrClimb.Resources.Coach;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.LookUrClimb.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete coaches")]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CoachesController(ICoachService coachService, IUserService userService, IMapper mapper)
    {
        _coachService = coachService;
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RegisterRequest request)
    {

        var result = await _coachService.RegisterAsync(request);

        if (!result.Success)
            throw new Exception(result.Message);

        var coachResource = _mapper.Map<Coach, SaveCoachResource>(result.Resource);

        return Created("Successfully created", coachResource);
    }

    [HttpGet]
    [Route("{coachId:int}")]
    public async Task<CoachResource?> GetOneAsync(int coachId)
    {
        var coach = await _coachService.GetOneAsync(coachId);

        if (coach == null) return null;
        var resource = _mapper.Map<Coach, CoachResource>(coach);

        return resource;
    }
}
