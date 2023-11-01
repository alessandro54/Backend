using LevelUpCenter.Security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LevelUpCenter.Coaching.Controllers;

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

    [AllowAnonymous]
    [HttpGet]
    [Route("/api/v1")]
    public IActionResult GetApiGreet()
    {
        return new JsonResult(new
        {
            Time = DateTime.Now,
            Greet = "Welcome to the Game Mentor API"
        });
    }
}
