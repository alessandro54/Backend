using LevelUpCenter.Coaching.Domain.Models;

namespace LevelUpCenter.Coaching.Resources.Coach;

public class CoachResource
{
    public string? Nickname { get; set; }
    public string? TwitchUrl { get; set; }
    public List<Course>? Courses { get; set; }
}
