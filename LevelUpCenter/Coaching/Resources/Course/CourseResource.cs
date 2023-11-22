using System.Text.Json.Serialization;

namespace LevelUpCenter.Coaching.Resources.Course;

public class CourseCoachResource
{
    public string? Nickname { get; set; }
    public string? ProfilePictureUrl { get; set; }
}

public class CourseGameResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconUrl { get; set; } = "";
}
public class CourseResource
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Published { get; set; }
    public decimal Price { get; set; }
    public CourseGameResource Game { get; set; }
    public CourseCoachResource Coach { get; set; }
    public DateTime CreatedAt { get; set; }
    [JsonIgnore] public DateTime? UpdatedAt { get; set; }
}
