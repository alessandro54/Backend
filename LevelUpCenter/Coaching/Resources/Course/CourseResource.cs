using System.Text.Json.Serialization;

namespace LevelUpCenter.Coaching.Resources.Course;

public class CourseResource
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Published { get; set; }
    public decimal Price { get; set; }
    public int GameId { get; set; }
    public int CoachId { get; set; }
    public DateTime CreatedAt { get; set; }
    [JsonIgnore] public DateTime? UpdatedAt { get; set; }
}
