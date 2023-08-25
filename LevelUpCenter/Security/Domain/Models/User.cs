using System.Text.Json.Serialization;

namespace LevelUpCenter.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    public UserRole Role { get; set; } = UserRole.User;

    [JsonIgnore]
    public string PasswordHash { get; set; }
}
