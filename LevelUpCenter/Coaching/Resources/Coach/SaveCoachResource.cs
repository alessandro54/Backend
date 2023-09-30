using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Security.Resources;

namespace LevelUpCenter.Coaching.Resources.Coach;

public class SaveCoachResource
{
    public string Nickname { get; set; } = "";
    public User User { get; set; }
}
