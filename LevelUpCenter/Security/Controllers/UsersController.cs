using AutoMapper;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using LevelUpCenter.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        try
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = "Wrong credentials" });
        }
    }

    [HttpGet("profile")]
    public Task<IActionResult> GetProfile()
    {
        var user = (User) HttpContext.Items["User"]!;

        var resource = _mapper.Map<User, UserResource>(user);

        return Task.FromResult<IActionResult>(Ok(resource));
    }

    [AuthorizeAdmin]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}
