using LevelUpCenter.LookUrClimb.Domain.Models;
using MySqlX.XDevAPI;

namespace LevelUpCenter.LookUrClimb.Resources.Coach;

public class CoachResource
{
    public string? Nickname { get; set; }
    public string? TwitchUrl { get; set; }
    public List<Course>? Courses { get; set; }
}
