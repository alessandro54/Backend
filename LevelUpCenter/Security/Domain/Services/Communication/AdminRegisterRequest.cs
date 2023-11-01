using System.ComponentModel.DataAnnotations;

namespace LevelUpCenter.Security.Domain.Services.Communication;

public class AdminRegisterRequest : RegisterRequest
{
    [Required] public string Secret { get; set; }
}
