using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete coaches")]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;
    private readonly IMapper _mapper;

    public CoachesController(ICoachService coachService, IMapper mapper)
    {
        _coachService = coachService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    [SwaggerOperation("[Public] Get all coaches")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var coaches = await _coachService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Coach>, IEnumerable<CoachResource>>(coaches!);
            return Ok(resources);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [SwaggerResponse(201, "Successfully created", typeof(SaveCoachResource))]
    [SwaggerOperation("Register as a Coach")]
    public async Task<IActionResult> PostAsync([FromBody] RegisterRequest request)
    {

        var result = await _coachService.RegisterAsync(request);

        if (!result.Success)
            throw new Exception(result.Message);

        var coachResource = _mapper.Map<Coach, SaveCoachResource>(result.Resource);

        return Created("Successfully created", coachResource);
    }

    [HttpGet]
    [Route("{id:int}")]
    [SwaggerOperation("Get a coach by id")]
    public async Task<CoachResource?> GetOneAsync(int id)
    {
        var coach = await _coachService.GetOneAsync(id);

        if (coach == null) return null;

        var resource = _mapper.Map<Coach, CoachResource>(coach);

        return resource;
    }
}
