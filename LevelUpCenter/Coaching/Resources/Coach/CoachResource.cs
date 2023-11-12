
using LevelUpCenter.Coaching.Resources.Course;

namespace LevelUpCenter.Coaching.Resources.Coach;

public class CoachResource
{
    public string? Nickname { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? TwitchUrl { get; set; }
    public List<CourseResource>? Courses { get; set; }
}
