using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Security.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly IAdminService _adminService;


    public AdminsController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("register")]
    [SwaggerOperation("Register as an admin")]
    public async Task<IActionResult> AdminRegister(AdminRegisterRequest request)
    {
        try
        {
            await _adminService.RegisterAsync(request);
            return Ok(new { message = "Registration successful" });
        }
        catch (Exception e)
        {
            return UnprocessableEntity(new { message = e.Message});
        }
    }

}
