using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}