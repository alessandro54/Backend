using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Security.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
}