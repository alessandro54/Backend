using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Security.Domain.Models;

namespace LevelUpCenter.Coaching.Resources.Coach;

public class CoachResource
{
    public string? Nickname { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? TwitchUrl { get; set; }
    public List<Course>? Courses { get; set; }
}
