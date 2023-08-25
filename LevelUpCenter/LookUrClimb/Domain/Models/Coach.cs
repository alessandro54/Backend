using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.LookUrClimb.Domain.Models;

public class Coach
{
    public int Id { get; set; }

    public string Nickname { get; set; } = "";

    public string TwitchUrl { get; set; } = "";

    public User User { get; set; }
}
