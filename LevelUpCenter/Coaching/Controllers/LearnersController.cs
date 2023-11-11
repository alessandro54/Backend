using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Learner;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;


[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Learners")]
public class LearnersController : ControllerBase
{
    private readonly ILearnerService _learnerService;
    private readonly IMapper _mapper;

    public LearnersController(ILearnerService learnerService, IMapper mapper)
    {
        _learnerService = learnerService;
        _mapper = mapper;
    }

    [AuthorizeAdmin]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var learners = await _learnerService.ListAsync();

            var resources =
                _mapper.Map<IEnumerable<Learner>, IEnumerable<LearnerResource>>(learners!);

            return Ok(resources);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("/api/v1/register")]
    public async Task<IActionResult> RegisterLearnerAsync([FromBody] RegisterRequest request)
    {
        var result = await _learnerService.RegisterAsync(request);

        if (!result.Success)
            throw new Exception(result.Message);

        var learnerResource = _mapper.Map<Learner, SaveLearnerResource>(result.Resource);

        return Created("Successfully created", learnerResource);
    }
}
