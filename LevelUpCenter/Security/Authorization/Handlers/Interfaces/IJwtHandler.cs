using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}