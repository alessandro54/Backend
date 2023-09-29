using LevelUpCenter.Security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.LookUrClimb.Controllers;

[ApiController]
[Route("/")]
public class HomeController
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(new
        {
            Time = DateTime.Now,
            Greet = "Hello, World!"
        });
    }
}
